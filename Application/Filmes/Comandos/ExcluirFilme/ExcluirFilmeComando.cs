using Application.Interfaces;

namespace Application.Filmes.Comandos.ExcluirFilme
{
    public sealed class ExcluirFilmeComando : IExcluirFilmeComando
    {
        private readonly IFilmesRepositorio _repositorio;

        public ExcluirFilmeComando(IFilmesRepositorio repositorio) =>
            _repositorio = repositorio;

        public bool Executar(int id) =>
            _repositorio.Excluir(id);
    }
}
