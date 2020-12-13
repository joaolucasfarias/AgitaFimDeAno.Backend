using Domain.Comum;
using Domain.Filmes.ValueObjects;

namespace Domain.Filmes
{
    public sealed class Filme : AggregateRoot
    {
        public Nome Nome { get; }
        public Descricao Descricao { get; }

        public Filme(int id) : base(id)
        {
        }
    }
}
