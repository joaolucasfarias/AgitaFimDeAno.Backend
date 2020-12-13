using Application.Interfaces;
using Domain.Comum;
using Domain.Filmes;
using System.Collections.Generic;

namespace Persistence.Comum
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : AggregateRoot
    {
        protected IList<Filme> Filmes;

        protected RepositorioBase() =>
            Filmes ??= new List<Filme>();

        public abstract bool Adicionar(T objeto, out string mensagem);

        public abstract bool Editar(T objet, out string mensagem);

        public abstract bool Excluir(int id, out string mensagem);

        public abstract IEnumerable<T> Listar();

        public abstract T Carregar(int id);
    }
}
