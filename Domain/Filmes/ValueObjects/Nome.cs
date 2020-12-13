using Domain.Comum;

namespace Domain.Filmes.ValueObjects
{
    public sealed class Nome : ValueObject<Nome>
    {
        public string Valor { get; }

        private Nome(string valor) =>
            Valor = valor;

        private Nome()
        {
        }

        public static Nome Criar(string valor, out bool sucesso)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length > 100)
            {
                sucesso = false;
                return new Nome();
            }

            sucesso = true;
            return new Nome(valor);
        }
    }
}
