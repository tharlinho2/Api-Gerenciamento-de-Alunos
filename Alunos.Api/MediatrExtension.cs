using System.Reflection;
using Alunos.Application.Alunos.Commands;
using Alunos.Domain.Alunos.Interface;
using Alunos.Infra.Contexts;
using Alunos.Infra.Repositories.Alunos;
using Alunos.Infra.Uow;
using Flunt.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Sample.MediatR.WebApi.Core.Extensions;
public static class MediatrExtension
{
    public static void AddMediatRApi(this IServiceCollection services)
    {
       // services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAlunoRepository, AlunoRepository>();
        services.AddMediatR(typeof(MediatrExtension));
        services.AddMediatR(typeof(CadastrarAlunoCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(AtualizarAlunoPorIdCommand).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(AtualizarAlunoPorIdCommand).GetTypeInfo().Assembly);
    }
}