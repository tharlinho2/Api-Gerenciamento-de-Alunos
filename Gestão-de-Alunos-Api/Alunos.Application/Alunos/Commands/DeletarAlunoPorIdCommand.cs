using Alunos.Application.Resultado;
using MediatR;

namespace Alunos.Application.Alunos.Commands
{
    public class DeletarAlunoPorIdCommand : IRequest<CommandResult<bool>>
    {
        public Guid Id { get; set; }
    }
}