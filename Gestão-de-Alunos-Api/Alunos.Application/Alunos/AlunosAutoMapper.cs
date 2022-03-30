using Alunos.Application.Alunos.ViewModels;
using Alunos.Domain.Alunos.Entities;
using AutoMapper;

namespace Alunos.Application.Alunos
{
    public class AlunosAutoMapper : Profile
    {
        public AlunosAutoMapper()
        {
            CreateMap<Aluno, AlunoViewModel>();
        }
    }
}
