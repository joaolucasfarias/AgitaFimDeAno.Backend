using Application.Filmes.Consultas.ListasFilmes;
using Domain.Comum;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepositorio<T> where T : AggregateRoot
    {
        bool Adicionar(T objeto);

        bool Editar(T objeto);

        bool Excluir(int id);

        IEnumerable<T> Listar(ParametrosDePesquisa parametrosDePesquisa);

        T Carregar(int id);
    }
}
