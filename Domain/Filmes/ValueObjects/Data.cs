using Domain.Comum;
using System;

namespace Domain.Filmes.ValueObjects
{
    public sealed class Data : ValueObject<Data>
    {
        public DateTime Valor { get; }

        private Data(DateTime valor) =>
            Valor = valor;

        private Data()
        {
        }

        public static Data Criar(DateTime valor, out bool sucesso)
        {
            if (valor == DateTime.MinValue || valor == DateTime.MaxValue)
            {
                sucesso = false;
                return new Data();
            }

            sucesso = true;
            return new Data(valor);
        }

        public static implicit operator DateTime(Data objeto) =>
            objeto.Valor;

        public static explicit operator Data(DateTime valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}