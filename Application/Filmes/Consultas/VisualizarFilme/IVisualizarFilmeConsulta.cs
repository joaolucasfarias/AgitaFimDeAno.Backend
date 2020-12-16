namespace Application.Filmes.Consultas.VisualizarFilme
{
    public interface IVisualizarFilmeConsulta
    {
        VisualizarFilmeDto Exetuar(int id, out bool sucesso);
    }
}
