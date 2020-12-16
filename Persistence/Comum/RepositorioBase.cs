using Application.Filmes.Consultas.ListasFilmes;
using Application.Interfaces;
using Domain.Comum;
using Domain.Filmes;
using System.Collections.Generic;

namespace Persistence.Comum
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : AggregateRoot
    {
        protected IList<Filme> Filmes;
        protected int UltimoId;

        protected RepositorioBase() =>
            Filmes ??= new List<Filme>();

        public abstract bool Adicionar(T objeto);

        public abstract bool Editar(T objeto);

        public abstract bool Excluir(int id);

        public abstract IEnumerable<T> Listar(ParametrosDePesquisa parametrosDePesquisa);

        public abstract T Carregar(int id);
    }
}
