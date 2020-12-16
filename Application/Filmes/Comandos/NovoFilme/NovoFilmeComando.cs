using Application.Interfaces;
using Domain.Filmes;
using Domain.Filmes.ValueObjects;

namespace Application.Filmes.Comandos.NovoFilme
{
    public sealed class NovoFilmeComando : INovoFilmeComando
    {
        private readonly IFilmesRepositorio _filmesRepositorio;

        public NovoFilmeComando(IFilmesRepositorio filmesRepositorio) =>
            _filmesRepositorio = filmesRepositorio;

        public bool Executar(NovoFilmeDto dto, out string mensagem)
        {
            var nome = Nome.Criar(dto.Nome, out var sucesso);
            if (!sucesso)
            {
                mensagem = "O nome não foi enviado corretamente.";
                return false;
            }

            var descricao = Descricao.Criar(dto.Descricao, out sucesso);
            if (!sucesso)
            {
                mensagem = "A descrição não foi enviada corretamente.";
                return false;
            }

            var filme = Filme.Novo(nome, descricao);

            sucesso = _filmesRepositorio.Adicionar(filme);
            
            mensagem = sucesso
                ? "Filme adicionado com sucesso."
                : "Erro ao adicionar o filme.";

            return sucesso;
        }
    }
}
