namespace Application.Filmes.Comandos.EditarFilme
{
    public interface IEditarFilmeComando
    {
        FilmeEditadoDto Executar(int id, EditarFilmeDto dto, out bool sucesso);
    }
}
