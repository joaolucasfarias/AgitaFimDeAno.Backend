using Application.Interfaces;
using Domain.Filmes;
using Persistence.Comum;
using System;
using System.Collections.Generic;

namespace Persistence.Filmes
{
    public sealed class FilmesRepositorio : RepositorioBase<Filme>, IFilmesRepositorio
    {
        public override bool Adicionar(Filme objeto, out string mensagem)
        {
            throw new NotImplementedException();
        }

        public override bool Editar(Filme objet, out string mensagem)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id, out string mensagem)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Filme> Listar()
        {
            throw new NotImplementedException();
        }

        public override Filme Carregar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
