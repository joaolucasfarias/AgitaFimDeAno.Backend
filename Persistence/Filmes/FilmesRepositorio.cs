using Application.Filmes.Consultas.ListasFilmes;
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
            objeto.ModificarId(++UltimoId);
            Filmes.Add(objeto);
            return true;
        }

        public override bool Editar(Filme objeto)
        {
            var filme = Filmes.FirstOrDefault(f => f.Equals(objeto));
            if (filme is null || filme.Id == 0)
                return false;

            filme.Editar(objeto);
            return true;
        }

        public override IEnumerable<Filme> Listar(ParametrosDePesquisa parametrosDePesquisa)
        {
            var filmes = Filmes as IEnumerable<Filme>;

            if (!string.IsNullOrWhiteSpace(parametrosDePesquisa.Titulo))
                filmes = filmes.Where(f => f.Nome.Valor.Contains(parametrosDePesquisa.Titulo));

            if (!string.IsNullOrWhiteSpace(parametrosDePesquisa.Genero))
                filmes = filmes.Where(f => f.Genero.Valor.Contains(parametrosDePesquisa.Genero));

            filmes = filmes
                .Skip((parametrosDePesquisa.Pagina - 1) * parametrosDePesquisa.Quantidade)
                .Take(parametrosDePesquisa.Quantidade);

            return filmes;
        }

        public override Filme Carregar(int id) =>
            id == 0
                ? null
                : Filmes.FirstOrDefault(f => f.Id == id);
    }
}
