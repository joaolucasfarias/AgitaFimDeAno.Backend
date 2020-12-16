namespace Application.Filmes.Consultas.VisualizarFilme
{
    public interface IVisualizarFilmeConsulta
    {
        VisualizarFilmeDto Executar(int id, out bool sucesso);
    }
}
