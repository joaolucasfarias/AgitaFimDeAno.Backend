using Domain.Filmes;
using Domain.Filmes.ValueObjects;

namespace Application.Filmes.Comandos.NovoFilme
{
    public sealed class NovoFilmeComando : INovoFilmeComando
    {
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

            mensagem = string.Empty;
            return true;
        }
    }
}
