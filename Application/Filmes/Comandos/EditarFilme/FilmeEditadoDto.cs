using System;
using System.Text.Json.Serialization;

namespace Application.Filmes.Comandos.EditarFilme
{
    public sealed class FilmeEditadoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string UrlFoto { get; set; }
        public DateTime DtLancamento { get; set; }
        public string Descricao { get; set; }
        public decimal Nota { get; set; }

        [JsonPropertyName("urlIMDb")]
        public string UrlImdb { get; set; }
        public string Genero { get; set; }
    }
}