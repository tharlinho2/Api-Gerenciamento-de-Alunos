using MediatR;

namespace Alunos.Application.Resultado
{
    public interface ICommand : IRequest<bool>
    {
    }

    public interface ICommand<TResponse> : IRequest<CommandResult<TResponse>>
    {
    }
}