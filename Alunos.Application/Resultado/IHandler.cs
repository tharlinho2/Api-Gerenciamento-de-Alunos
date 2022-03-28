namespace Alunos.Application.Resultado
{
    public interface IHandler<T> where T : ICommand
    {
       // CommandResult Handle(T command);
    }
}