using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Filmes.Consultas.ListasFilmes
{
    public sealed class ListarFilmesConsulta : IListarFilmesConsulta
    {
        private readonly IFilmesRepositorio _filmesRepositorio;

        public ListarFilmesConsulta(IFilmesRepositorio filmesRepositorio) =>
            _filmesRepositorio = filmesRepositorio;

        public IEnumerable<ListarFilmesDto> Executar() =>
            _filmesRepositorio.Listar().Select(f =>
                    new ListarFilmesDto
                    {
                        Nome = f.Nome,
                        Descricao = f.Descricao
                    })
                .ToList();
    }
}
