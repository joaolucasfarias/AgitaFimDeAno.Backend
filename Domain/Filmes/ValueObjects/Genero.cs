using Domain.Comum;
using System;

namespace Domain.Filmes.ValueObjects
{
    public class Genero : ValueObject<Genero>
    {
        public string Valor { get; }

        private Genero(string valor) =>
            Valor = valor;

        private Genero()
        {
        }

        public static Genero Criar(string valor, out bool sucesso)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length > 200)
            {
                sucesso = false;
                return new Genero();
            }

            sucesso = true;
            return new Genero(valor);
        }

        public override string ToString() =>
            Valor;

        public static implicit operator string(Genero objeto) =>
            objeto.Valor;

        public static explicit operator Genero(string valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}
