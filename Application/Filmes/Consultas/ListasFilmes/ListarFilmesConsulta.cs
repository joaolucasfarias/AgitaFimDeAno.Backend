using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Application.Filmes.Consultas.ListasFilmes
{
    public sealed class ListarFilmesConsulta : IListarFilmesConsulta
    {
        private readonly IFilmesRepositorio _repositorio;

        public ListarFilmesConsulta(IFilmesRepositorio filmesRepositorio) =>
            _repositorio = filmesRepositorio;

        public IEnumerable<ListarFilmesDto> Executar() =>
            _repositorio.Listar().Select(f =>
                    new ListarFilmesDto
                    {
                        Id = f.Id,
                        Titulo = f.Nome,
                        UrlFoto = f.Foto,
                        DtLancamento = f.DataDeLancamento,
                        Descricao = f.Descricao,
                        Nota = f.Nota,
                        UrlImdb = f.PerfilNoImdb,
                        Genero = f.Genero
                    })
                .ToList();
    }
}
