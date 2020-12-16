using Application.Interfaces;
using Domain.Filmes;
using Domain.Filmes.ValueObjects;

namespace Application.Filmes.Comandos.EditarFilme
{
    public sealed class EditarFilmeComando : IEditarFilmeComando
    {
        private readonly IFilmesRepositorio _repositorio;

        public EditarFilmeComando(IFilmesRepositorio repositorio) =>
            _repositorio = repositorio;

        public FilmeEditadoDto Executar(int id, EditarFilmeDto dto, out bool sucesso)
        {
            if (id <= 0)
            {
                sucesso = false;
                return null;
            }

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

            var filme = Filme.Existente(id, nome, foto, dataDeLancamento, descricao, nota, imdb, genero);

            _repositorio.Editar(filme);

            sucesso = true;

            return new FilmeEditadoDto
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
