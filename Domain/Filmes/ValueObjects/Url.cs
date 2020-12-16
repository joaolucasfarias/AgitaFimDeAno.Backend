using Domain.Comum;
using System;

namespace Domain.Filmes.ValueObjects
{
    public sealed class Url : ValueObject<Url>
    {
        public string Valor { get; }

        private Url(string valor) =>
            Valor = valor;

        private Url()
        {
        }

        public static Url Criar(string valor, out bool sucesso)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                sucesso = false;
                return new Url();
            }

            sucesso = true;
            return new Url(valor);
        }

        public override string ToString() =>
            Valor;

        public static implicit operator string(Url objeto) =>
            objeto.Valor;

        public static explicit operator Url(string valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}
