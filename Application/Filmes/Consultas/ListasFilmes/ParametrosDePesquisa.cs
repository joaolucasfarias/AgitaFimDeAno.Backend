namespace Application.Filmes.Consultas.ListasFilmes
{
    public sealed class ParametrosDePesquisa
    {
        public int Pagina { get; }
        public int Quantidade { get; }
        public string Titulo { get; }
        public string Genero { get; }

        public ParametrosDePesquisa(int pagina, int quantidade, string titulo, string genero)
        {
            Pagina = pagina;
            Quantidade = quantidade;
            Titulo = titulo;
            Genero = genero;
        }
    }
}
