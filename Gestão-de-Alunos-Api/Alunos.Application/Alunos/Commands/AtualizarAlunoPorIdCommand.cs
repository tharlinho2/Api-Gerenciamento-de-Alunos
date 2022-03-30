using Alunos.Application.Resultado;
using MediatR;

namespace Alunos.Application.Alunos.Commands
{
    public class AtualizarAlunoPorIdCommand : IRequest<CommandResult<bool>>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}