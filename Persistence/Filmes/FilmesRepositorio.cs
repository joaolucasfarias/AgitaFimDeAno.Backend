using Application.Interfaces;
using Domain.Filmes;
using Persistence.Comum;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Filmes
{
    public sealed class FilmesRepositorio : RepositorioBase<Filme>, IFilmesRepositorio
    {
        public override bool Adicionar(Filme objeto)
        {
            objeto.ModificarId(Filmes.Count + 1);
            Filmes.Add(objeto);
            return true;
        }

        public override bool Editar(Filme objeto)
        {
            var filme = Filmes.FirstOrDefault(f => f == objeto);
            if (filme is null || filme.Id == 0)
                return false;

            filme.Editar(objeto);
            return true;
        }

        public override bool Excluir(int id)
        {
            if (id == 0)
                return false;

            var filme = Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is null)
                return false;

            return Filmes.Remove(filme);
        }

        public override IEnumerable<Filme> Listar() =>
            Filmes.OrderBy(f => f.Id);

        public override Filme Carregar(int id) =>
            id == 0
                ? null
                : Filmes.FirstOrDefault(f => f.Id == id);
    }
}
