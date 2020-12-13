namespace Application.Filmes.Comandos.NovoFilme
{
    public interface INovoFilmeComando
    {
        bool Executar(NovoFilmeDto dto, out string mensagem);
    }
}
