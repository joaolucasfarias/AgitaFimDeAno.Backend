using Application.Interfaces;
using Domain.Filmes;
using Persistence.Comum;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Filmes
{
    public sealed class FilmesRepositorio : RepositorioBase<Filme>, IFilmesRepositorio
    {
        public override bool Adicionar(Filme objeto, out string mensagem)
        {
            objeto.ModificarId(Filmes.Count + 1);
            Filmes.Add(objeto);
            mensagem = "Filme adicionado com sucesso.";
            return true;
        }

        public override bool Editar(Filme objeto, out string mensagem)
        {
            var filme = Filmes.FirstOrDefault(f => f == objeto);
            if (filme is null || filme.Id == 0)
            {
                mensagem = "Filme não encontrado.";
                return false;
            }

            filme.Editar(objeto);
            mensagem = "Filme editado com sucesso.";
            return true;
        }

        public override bool Excluir(int id, out string mensagem)
        {
            if (id == 0)
            {
                mensagem = "Filme não encontrado.";
                return false;
            }

            var filme = Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is null)
            {
                mensagem = "Filme não encontrado.";
                return false;
            }

            Filmes.Remove(filme);
            mensagem = "Filme excluído com sucesso.";
            return true;
        }

        public override IEnumerable<Filme> Listar() =>
            Filmes.OrderBy(f => f.Id);

        public override Filme Carregar(int id, out string mensagem)
        {
            if (id == 0)
            {
                mensagem = "Filme não encontrado.";
                return null;
            }

            var filme = Filmes.FirstOrDefault(f => f.Id == id);
            if (filme is null)
            {
                mensagem = "Filme não encontrado.";
                return null;
            }

            mensagem = "Filme carregado com sucesso.";
            return filme;
        }
    }
}
