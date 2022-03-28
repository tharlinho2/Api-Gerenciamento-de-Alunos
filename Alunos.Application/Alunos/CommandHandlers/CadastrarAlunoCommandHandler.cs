using Alunos.Application.Alunos.Commands;
using Alunos.Application.Resultado;
using Alunos.Domain.Alunos.Entities;
using Alunos.Domain.Alunos.Interface;
using Alunos.Infra.Uow;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alunos.Application.Alunos.CommandHandlers
{
    public class CadastrarAlunoCommandHandler : Notifiable, IRequestHandler<CadastrarAlunoCommand, CommandResult<bool>>
    {
        private readonly IAlunoRepository _uow;

        public CadastrarAlunoCommandHandler(IAlunoRepository uow)
        {
            _uow = uow;
        }

        public async Task<CommandResult<bool>> Handle(CadastrarAlunoCommand command, CancellationToken cancellation)
        {
            var alunoExiste = _uow.ObterPorCpf(command.CPF);
            if (alunoExiste != null)
            {
                return new CommandResult<bool>(false, "Cpf já cadastrado!");
            }

            alunoExiste = _uow.ObterPorEmail(command.CPF);
            if (alunoExiste != null)
            {
                return new CommandResult<bool>(false, "Email já cadastrado!");
            }

            alunoExiste = _uow.ObterPorRegistroAcademico(command.RA);
            if (alunoExiste != null)
            {
                return new CommandResult<bool>(false, "RA já cadastrado!");
            }

            var aluno = new Aluno(
                command.Nome,
                command.Email,
                command.RA,
                command.CPF
            );

            _uow.Adicionar(aluno);

            _uow.Commit();

            return new CommandResult<bool>(true);
        }

    }
}
