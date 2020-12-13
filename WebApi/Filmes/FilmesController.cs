using Application.Filmes.Comandos.NovoFilme;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Filmes
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly INovoFilmeComando _novoFilmeComando;

        public FilmesController(INovoFilmeComando novoFilmeComando)
        {
            _novoFilmeComando = novoFilmeComando;
        }

        [HttpPost]
        public IActionResult Post([FromBody] NovoFilmeDto dto)
        {
            var resultado = _novoFilmeComando.Executar(dto, out var mensagem);
            if (resultado)
                return Ok(mensagem);

            return BadRequest(mensagem);
        }
    }
}
