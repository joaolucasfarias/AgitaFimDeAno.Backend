using Domain.Comum;
using Domain.Filmes.ValueObjects;
using System;

namespace Domain.Filmes
{
    public sealed class Filme : AggregateRoot
    {
        public Nome Nome { get; private set; }
        public Url Foto { get; private set; }
        public DataDeLancamento DataDeLancamento { get; private set; }
        public Descricao Descricao { get; private set; }
        public Nota Nota { get; private set; }
        public Url PerfilNoImdb { get; private set; }
        public Genero Genero { get; private set; }

        public void ModificarId(int novoId) =>
            Id = novoId;

        public void Editar(Filme outro)
        {
            Nome = outro.Nome;
            Descricao = outro.Descricao;
            Foto = outro.Foto;
            DataDeLancamento = outro.DataDeLancamento;
            Nota = outro.Nota;
            PerfilNoImdb = outro.PerfilNoImdb;
            Genero = outro.Genero;
        }

        private Filme(int id, Nome nome, Url foto, DataDeLancamento dataDeLancamento, Descricao descricao, Nota nota, Url perfilNoImdb, Genero genero) : base(id)
        {
            Nome = nome;
            Foto = foto;
            DataDeLancamento = dataDeLancamento;
            Descricao = descricao;
            Nota = nota;
            PerfilNoImdb = perfilNoImdb;
            Genero = genero;
        }

        public static Filme Novo(Nome nome, Url foto, DataDeLancamento dataDeLancamento, Descricao descricao, Nota nota, Url perfilNoImdb, Genero genero)
        {
            if (nome is null)
                throw new ArgumentNullException(nameof(nome));

            if (foto is null)
                throw new ArgumentNullException(nameof(foto));

            if (dataDeLancamento is null)
                throw new ArgumentNullException(nameof(dataDeLancamento));

            if (descricao is null)
                throw new ArgumentNullException(nameof(descricao));

            if (nota is null)
                throw new ArgumentNullException(nameof(nota));

            if (perfilNoImdb is null)
                throw new ArgumentNullException(nameof(perfilNoImdb));

            if (genero is null)
                throw new ArgumentNullException(nameof(genero));

            return new Filme(0, nome, foto, dataDeLancamento, descricao, nota, perfilNoImdb, genero);
        }

        public static Filme Existente(int id, Nome nome, Url foto, DataDeLancamento dataDeLancamento, Descricao descricao, Nota nota, Url perfilNoImdb, Genero genero)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            if (nome is null)
                throw new ArgumentNullException(nameof(nome));

            if (foto is null)
                throw new ArgumentNullException(nameof(foto));

            if (dataDeLancamento is null)
                throw new ArgumentNullException(nameof(dataDeLancamento));

            if (descricao is null)
                throw new ArgumentNullException(nameof(descricao));

            if (nota is null)
                throw new ArgumentNullException(nameof(nota));

            if (perfilNoImdb is null)
                throw new ArgumentNullException(nameof(perfilNoImdb));

            if (genero is null)
                throw new ArgumentNullException(nameof(genero));

            return new Filme(id, nome, foto, dataDeLancamento, descricao, nota, perfilNoImdb, genero);
        }
    }
}
