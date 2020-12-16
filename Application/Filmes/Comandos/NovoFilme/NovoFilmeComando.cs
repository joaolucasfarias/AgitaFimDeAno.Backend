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
            var nome = Nome.Criar(dto.Titulo, out var sucesso);
            if (!sucesso)
            {
                mensagem = "O nome não foi enviado corretamente.";
                return false;
            }

            var foto = Url.Criar(dto.UrlFoto, out sucesso);
            if (!sucesso)
            {
                mensagem = "A URL da foto não foi enviada corretamente.";
                return false;
            }

            var dataDeLancamento = DataDeLancamento.Criar(dto.DtLancamento, out sucesso);
            if (!sucesso)
            {
                mensagem = "A data de lançamento não foi enviada corretamente.";
                return false;
            }

            var descricao = Descricao.Criar(dto.Descricao, out sucesso);
            if (!sucesso)
            {
                mensagem = "A descrição não foi enviada corretamente.";
                return false;
            }

            var nota = Nota.Criar(dto.Nota, out sucesso);
            if (!sucesso)
            {
                mensagem = "A nota não foi enviada corretamente.";
                return false;
            }

            var imdb = Url.Criar(dto.UrlImdb, out sucesso);
            if (!sucesso)
            {
                mensagem = "A URL do IMDB não foi enviada corretamente.";
                return false;
            }

            var genero = Genero.Criar(dto.Genero, out sucesso);
            if (!sucesso)
            {
                mensagem = "O gênero não foi enviado corretamente.";
                return false;
            }

            var filme = Filme.Novo(nome, foto, dataDeLancamento, descricao, nota, imdb, genero);

            sucesso = _filmesRepositorio.Adicionar(filme);
            
            mensagem = sucesso
                ? "Filme adicionado com sucesso."
                : "Erro ao adicionar o filme.";

            return sucesso;
        }
    }
}
