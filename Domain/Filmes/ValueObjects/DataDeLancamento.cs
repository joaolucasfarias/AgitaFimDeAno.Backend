using Domain.Comum;
using System;

namespace Domain.Filmes.ValueObjects
{
    public sealed class DataDeLancamento : ValueObject<DataDeLancamento>
    {
        public DateTime Valor { get; }

        private DataDeLancamento(DateTime valor) =>
            Valor = valor;

        private DataDeLancamento()
        {
        }

        public static DataDeLancamento Criar(DateTime valor, out bool sucesso)
        {
            if (valor == DateTime.MinValue || valor == DateTime.MaxValue)
            {
                sucesso = false;
                return new DataDeLancamento();
            }

            sucesso = true;
            return new DataDeLancamento(valor);
        }

        public static implicit operator DateTime(DataDeLancamento objeto) =>
            objeto.Valor;

        public static explicit operator DataDeLancamento(DateTime valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}