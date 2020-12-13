using System;
using Domain.Comum;
using Domain.Filmes.ValueObjects;

namespace Domain.Filmes
{
    public sealed class Filme : AggregateRoot
    {
        public Nome Nome { get; }
        public Descricao Descricao { get; }

        private Filme(int id) : base(id)
        {
        }

        private Filme(Nome nome, Descricao descricao) : this(0)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public static Filme Novo(Nome nome, Descricao descricao)
        {
            if (nome is null)
                throw new ArgumentNullException(nameof(nome));

            if (descricao is null)
                throw new ArgumentNullException(nameof(nome));

            return new Filme(nome, descricao);
        }
    }
}
