using Domain.Comum;
using Domain.Filmes.ValueObjects;
using System;

namespace Domain.Filmes
{
    public sealed class Filme : AggregateRoot
    {
        public Nome Nome { get; private set; }
        public Descricao Descricao { get; private set; }

        public void ModificarId(int novoId) =>
            Id = novoId;

        public void Editar(Filme filme)
        {
            Nome = filme.Nome;
            Descricao = filme.Descricao;
        }

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
