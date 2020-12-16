using Application.Interfaces;

namespace Application.Filmes.Consultas.VisualizarFilme
{
    public sealed class VisualizarFilmeConsulta : IVisualizarFilmeConsulta
    {
        private readonly IFilmesRepositorio _repositorio;

        public VisualizarFilmeConsulta(IFilmesRepositorio repositorio) =>
            _repositorio = repositorio;

        public VisualizarFilmeDto Exetuar(int id, out bool sucesso)
        {
            var filme = _repositorio.Carregar(id);
            if (filme is null)
            {
                sucesso = false;
                return null;
            }

            sucesso = true;

            return new VisualizarFilmeDto
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
