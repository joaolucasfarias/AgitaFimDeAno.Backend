using Application.Filmes.Comandos.NovoFilme;
using Application.Filmes.Consultas.ListasFilmes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApi.Filmes
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly INovoFilmeComando _novoFilme;
        private readonly IListarFilmesConsulta _listarFilmes;

        public FilmesController(
            INovoFilmeComando novoFilme,
            IListarFilmesConsulta listarFilmes)
        {
            _novoFilme = novoFilme;
            _listarFilmes = listarFilmes;
        }

        [HttpPost]
        public IActionResult NovoFilme([FromBody] NovoFilmeDto dto)
        {
            var resultado = _novoFilme.Executar(dto, out var mensagem);
            if (resultado)
                return Ok(mensagem);

            return BadRequest(mensagem);
        }

        [HttpGet]
        public IEnumerable<ListarFilmesDto> ListarFilmes() =>
            _listarFilmes.Executar();
    }
}
