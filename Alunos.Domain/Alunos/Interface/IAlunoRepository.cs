using Alunos.Domain.Alunos.Entities;

namespace Alunos.Domain.Alunos.Interface
{
    public interface IAlunoRepository
    {
        Aluno ObterAlunoPorId(Guid id);
        IEnumerable<Aluno> ObterTodos();
        Aluno ObterPorRegistroAcademico(string ra);
        Aluno ObterPorCpf(string cpf);
        Aluno ObterPorEmail(string email);
        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Remover(Aluno aluno);
        void Commit();
    }
}
