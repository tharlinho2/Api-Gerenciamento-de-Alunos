using Alunos.Application.Alunos.Commands;
using FluentValidation;

namespace Alunos.Application.Alunos.CommandValidators
{
    public class CadastrarAlunoCommandValidator : AbstractValidator<CadastrarAlunoCommand>
    {
        public CadastrarAlunoCommandValidator()
        {
            RuleFor(n => n.Nome)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                    .WithMessage("Nome no minimo 3 caracteres!")
                .MaximumLength(50)
                    .WithMessage("Nome no máximo 50 caracteres!");

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(d => d.DataNascimento)
                .NotNull().NotEmpty()
                    .WithMessage("Data de Nascimento obrigatória!")
                .LessThan(DateTime.Now.Date.AddYears(3))
                    .WithMessage("O Aluno(a) precisa ter no mínimo 3 anos de idade!")
                .GreaterThan(DateTime.Now.Date.AddYears(-100))
                    .WithMessage("O Aluno(a) precisa ter no máximo 100 anos de idade!");

            RuleFor(r => r.RA)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1)
                    .WithMessage("Registro Acadêmico inválido!");

            RuleFor(c => c.CPF)
                .NotNull()
                .NotEmpty()
                .MaximumLength(11)
                .MinimumLength(11)
                    .WithMessage("CPF inválido!");
        }
    }
}
