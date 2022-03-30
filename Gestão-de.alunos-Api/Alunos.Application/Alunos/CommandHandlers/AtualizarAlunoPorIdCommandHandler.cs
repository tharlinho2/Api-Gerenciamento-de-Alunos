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
    public class AtualizarAlunoPorIdCommandHandler : Notifiable, IRequestHandler<AtualizarAlunoPorIdCommand, CommandResult<bool>>
    {
        private readonly IAlunoRepository _uow;

        public AtualizarAlunoPorIdCommandHandler(IAlunoRepository uow)
        {
            _uow = uow;
        }

        public async Task<CommandResult<bool>> Handle(AtualizarAlunoPorIdCommand command, CancellationToken cancellation)
        {
            var alunoExiste = _uow.ObterAlunoPorId(command.Id);
            if (alunoExiste == null)
            {
                return new CommandResult<bool>(false, "Aluno não encontrado!");
            }
            
            if(command.Nome != null)
                alunoExiste.Nome = command.Nome;

            if(command.Email != null)
                alunoExiste.Email = command.Email;

            _uow.Atualizar(alunoExiste);
            _uow.Commit();

            return new CommandResult<bool>(true);
        }

    }
}
