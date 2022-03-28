namespace Alunos.Domain.Alunos.Entities
{
    public abstract class BaseEntity
    {
        public Guid? Id { get; private set; }
        //public DateTime CadastradoEm { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            //CadastradoEm = DateTime.Now;
        }
    }
}
