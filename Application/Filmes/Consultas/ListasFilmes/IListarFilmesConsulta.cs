using System.Collections.Generic;

namespace Application.Filmes.Consultas.ListasFilmes
{
    public interface IListarFilmesConsulta
    {
        IEnumerable<ListarFilmesDto> Executar(ParametrosDePesquisa parametrosDePesquisa);
    }
}
