using Alunos.Application.Resultado;
using MediatR;

namespace Alunos.Application.Alunos.Commands
{
    public class CadastrarAlunoCommand : IRequest<CommandResult<bool>>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
