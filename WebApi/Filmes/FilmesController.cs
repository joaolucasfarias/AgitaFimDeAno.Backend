using Application.Filmes.Comandos.NovoFilme;
using Application.Filmes.Consultas.ListasFilmes;
using Application.Filmes.Consultas.VisualizarFilme;
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
        private readonly IVisualizarFilmeConsulta _visualizarFilme;

        public FilmesController(
            INovoFilmeComando novoFilme,

            IListarFilmesConsulta listarFilmes,
            IVisualizarFilmeConsulta visualizarFilme)
        {
            _novoFilme = novoFilme;
            _listarFilmes = listarFilmes;
            _visualizarFilme = visualizarFilme;
        }

        [HttpPost]
        public IActionResult NovoFilme([FromBody] NovoFilmeDto dto)
        {
            var filme = _novoFilme.Executar(dto, out var sucesso);
            if (sucesso)
                return Ok(filme);

            return BadRequest(filme);
        }

        [HttpGet]
        public IEnumerable<ListarFilmesDto> ListarFilmes() =>
            _listarFilmes.Executar();


        [HttpGet("{id}")]
        public IActionResult VisualizarFilme(int id)
        {
            var filme = _visualizarFilme.Exetuar(id, out var sucesso);
            if (sucesso)
                return Ok(filme);

            return BadRequest(filme);
        }
    }
}
