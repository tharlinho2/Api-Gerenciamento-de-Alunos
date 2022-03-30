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
    public class DeletarAlunoPorIdCommandHandler : Notifiable, IRequestHandler<DeletarAlunoPorIdCommand, CommandResult<bool>>
    {
        private readonly IAlunoRepository _uow;

        public DeletarAlunoPorIdCommandHandler(IAlunoRepository uow)
        {
            _uow = uow;
        }

        public async Task<CommandResult<bool>> Handle(DeletarAlunoPorIdCommand command, CancellationToken cancellation)
        {
            var alunoExiste = _uow.ObterAlunoPorId(command.Id);
            if (alunoExiste == null)
            {
                return new CommandResult<bool>(false, "Aluno não encontrado!");
            }

            _uow.Remover(alunoExiste);
            _uow.Commit();

            return new CommandResult<bool>(true);
        }

    }
}

