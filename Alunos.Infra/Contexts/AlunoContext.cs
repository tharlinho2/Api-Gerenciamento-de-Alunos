using Alunos.Domain.Alunos.Entities;
using Alunos.Domain.Alunos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

    }
}