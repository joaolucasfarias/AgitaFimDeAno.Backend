namespace Application.Filmes.Comandos.NovoFilme
{
    interface INovoFilmeComando
    {
        bool Executar(NovoFilmeDto dto, out string mensagem);
    }
}
