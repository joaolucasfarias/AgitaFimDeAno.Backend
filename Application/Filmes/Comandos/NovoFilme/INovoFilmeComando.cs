namespace Application.Filmes.Comandos.NovoFilme
{
    public interface INovoFilmeComando
    {
        FilmeCriadoDto Executar(NovoFilmeDto dto, out bool sucesso);
    }
}
