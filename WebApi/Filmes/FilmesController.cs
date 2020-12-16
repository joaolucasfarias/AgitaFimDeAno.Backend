using Application.Filmes.Comandos.EditarFilme;
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
        private readonly IEditarFilmeComando _editarFilme;

        private readonly IListarFilmesConsulta _listarFilmes;
        private readonly IVisualizarFilmeConsulta _visualizarFilme;

        public FilmesController(
            INovoFilmeComando novoFilme,
            IEditarFilmeComando editarFilme,

            IListarFilmesConsulta listarFilmes,
            IVisualizarFilmeConsulta visualizarFilme)
        {
            _novoFilme = novoFilme;
            _editarFilme = editarFilme;

            _listarFilmes = listarFilmes;
            _visualizarFilme = visualizarFilme;
        }

        [HttpPost]
        public IActionResult NovoFilme([FromBody] NovoFilmeDto dto)
        {
            var retorno = _novoFilme.Executar(dto, out var sucesso);
            if (sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        [HttpGet]
        public IEnumerable<ListarFilmesDto> ListarFilmes() =>
            _listarFilmes.Executar();


        [HttpGet("{id}")]
        public IActionResult VisualizarFilme(int id)
        {
            var retorno = _visualizarFilme.Exetuar(id, out var sucesso);
            if (sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }

        [HttpPut("{id}")]
        public IActionResult EditarFilme([FromRoute] int id, [FromBody] EditarFilmeDto dto)
        {
            var retorno = _editarFilme.Executar(id, dto, out var sucesso);
            if (sucesso)
                return Ok(retorno);

            return BadRequest(retorno);
        }
    }
}
