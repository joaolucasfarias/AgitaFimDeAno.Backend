using Domain.Comum;

namespace Domain.Filmes.ValueObjects
{
    public sealed class Nota : ValueObject<Nota>
    {
        public decimal Valor { get; }

        private Nota(decimal valor) =>
            Valor = valor;

        private Nota()
        {
        }

        public static Nota Criar(decimal valor, out bool sucesso)
        {
            if (valor < 0 || valor > 10)
            {
                sucesso = false;
                return new Nota();
            }

            sucesso = true;
            return new Nota(valor);
        }
    }
}
