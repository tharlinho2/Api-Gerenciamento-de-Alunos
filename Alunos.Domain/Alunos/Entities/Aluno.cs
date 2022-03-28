namespace Alunos.Domain.Alunos.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Ra { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        public Aluno(string nome, string email, string ra, string cpf)
        {
            Nome = nome;
            Email = email;
            Ra = ra;
            Cpf = cpf;
            Ativo = true;
        }
    }
}
