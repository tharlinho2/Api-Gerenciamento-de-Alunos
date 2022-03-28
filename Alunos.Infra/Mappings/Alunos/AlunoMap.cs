using Alunos.Domain.Alunos.Entities;
using Alunos.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alunos.Infra.Mappings.Alunos
{
    public class AlunoMap : DataContext
    {
        public AlunoMap(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Aluno>()
                .ToTable(nameof(Aluno));

            builder.Entity<Aluno>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Entity<Aluno>()
                .Property(x => x.Nome)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Entity<Aluno>()
                .Property(x => x.Cpf)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Entity<Aluno>()
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Entity<Aluno>()
                .Property(x => x.Ra)
                .HasColumnType("varchar")
                .IsRequired();


            builder.Entity<Aluno>()
                .Property(x => x.Ativo)
                .HasColumnType("boolean");
        }

    }
}