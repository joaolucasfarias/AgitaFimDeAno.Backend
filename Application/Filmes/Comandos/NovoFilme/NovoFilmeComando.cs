using Application.Interfaces;
using Domain.Filmes;
using Domain.Filmes.ValueObjects;

namespace Application.Filmes.Comandos.NovoFilme
{
    public sealed class NovoFilmeComando : INovoFilmeComando
    {
        private readonly IFilmesRepositorio _repositorio;

        public NovoFilmeComando(IFilmesRepositorio filmesRepositorio) =>
            _repositorio = filmesRepositorio;

        public FilmeCriadoDto Executar(NovoFilmeDto dto, out bool sucesso)
        {
            var nome = Nome.Criar(dto.Titulo, out sucesso);
            if (!sucesso)
                return null;

            var foto = Url.Criar(dto.UrlFoto, out sucesso);
            if (!sucesso)
                return null;

            var dataDeLancamento = DataDeLancamento.Criar(dto.DtLancamento, out sucesso);
            if (!sucesso)
                return null;

            var descricao = Descricao.Criar(dto.Descricao, out sucesso);
            if (!sucesso)
                return null;

            var nota = Nota.Criar(dto.Nota, out sucesso);
            if (!sucesso)
                return null;

            var imdb = Url.Criar(dto.UrlImdb, out sucesso);
            if (!sucesso)
                return null;

            var genero = Genero.Criar(dto.Genero, out sucesso);
            if (!sucesso)
                return null;

            var filme = Filme.Novo(nome, foto, dataDeLancamento, descricao, nota, imdb, genero);

            sucesso = _repositorio.Adicionar(filme);

            return new FilmeCriadoDto
            {
                Id = filme.Id,
                Nota = filme.Nota,
                Genero = filme.Genero,
                UrlFoto = filme.Foto,
                DtLancamento = filme.DataDeLancamento,
                Descricao = filme.Descricao,
                Titulo = filme.Nome,
                UrlImdb = filme.PerfilNoImdb
            };
        }
    }
}
