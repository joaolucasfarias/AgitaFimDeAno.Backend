using System;

namespace Application.Filmes.Comandos.NovoFilme
{
    public sealed class NovoFilmeDto
    {
        public string Titulo { get; set; }
        public string UrlFoto { get; set; }
        public DateTime DtLancamento { get; set; }
        public string Descricao { get; set; }
        public decimal Nota { get; set; }
        public string UrlImdb { get; set; }
        public string Genero { get; set; }
    }
}
