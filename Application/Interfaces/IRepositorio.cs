using Domain.Comum;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepositorio<T> where T : AggregateRoot
    {
        bool Adicionar(T objeto, out string mensagem);

        bool Editar(T objet, out string mensagem);

        bool Excluir(int id, out string mensagem);

        IEnumerable<T> Listar();

        T Carregar(int id);
    }
}
