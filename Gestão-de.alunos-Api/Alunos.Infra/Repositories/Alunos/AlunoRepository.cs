using System.Linq.Expressions;
using Alunos.Domain.Alunos.Entities;
using Alunos.Domain.Alunos.Interface;
using Alunos.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Repositories.Alunos
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
        }

        public void Remover(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
        }

        public Aluno ObterAlunoPorId(Guid id)
        {
            return _context.Alunos
                    .FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Aluno> ObterTodos()
        {
            var alunos = 
                _context.Alunos
                    .AsNoTracking()
                    .OrderBy(c => c.Nome);

            return alunos;
        }

        public Aluno ObterPorRegistroAcademico(string ra)
        {
              return _context.Alunos
                        .FirstOrDefault(c => c.Ra == ra);
        }

        public Aluno ObterPorCpf(string cpf)
        {
            return _context.Alunos
                    .FirstOrDefault(c => c.Cpf == cpf);
        }

        public Aluno ObterPorEmail(string email)
        {
            return _context.Alunos
                    .FirstOrDefault(c => c.Email == email);
        }

    }
}