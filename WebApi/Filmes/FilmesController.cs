using Application.Filmes.Comandos.EditarFilme;
using Application.Filmes.Comandos.ExcluirFilme;
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
        private readonly IExcluirFilmeComando _excluirFilme;

        private readonly IListarFilmesConsulta _listarFilmes;
        private readonly IVisualizarFilmeConsulta _visualizarFilme;

        public FilmesController(
            INovoFilmeComando novoFilme,
            IEditarFilmeComando editarFilme,
            IExcluirFilmeComando excluirFilme,

            IListarFilmesConsulta listarFilmes,
            IVisualizarFilmeConsulta visualizarFilme)
        {
            _novoFilme = novoFilme;
            _editarFilme = editarFilme;
            _excluirFilme = excluirFilme;

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
        public IEnumerable<ListarFilmesDto> ListarFilmes(
            [FromQuery(Name = "_page")] int pagina,
            [FromQuery(Name = "_limit")] int quantidade,
            [FromQuery(Name = "q")] string titulo,
            [FromQuery] string genero) =>
            _listarFilmes.Executar(new ParametrosDePesquisa(pagina, quantidade, titulo, genero));

        [HttpGet("{id}")]
        public IActionResult VisualizarFilme(int id)
        {
            var retorno = _visualizarFilme.Executar(id, out var sucesso);
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

        [HttpDelete("{id}")]
        public IActionResult ExcluirFilme(int id)
        {
            var retorno = _excluirFilme.Executar(id);
            if (retorno)
                return Ok();

            return BadRequest();
        }
    }
}
