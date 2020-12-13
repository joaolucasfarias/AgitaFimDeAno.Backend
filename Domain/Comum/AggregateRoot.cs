namespace Domain.Comum
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(int id) : base(id) { }
    }
}