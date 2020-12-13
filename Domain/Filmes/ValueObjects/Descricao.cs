using Domain.Comum;
using System;

namespace Domain.Filmes.ValueObjects
{
    public class Descricao : ValueObject<Descricao>
    {
        public string Valor { get; }

        private Descricao(string valor) =>
            Valor = valor;

        private Descricao()
        {
        }

        public static Descricao Criar(string valor, out bool sucesso)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length > 3000)
            {
                sucesso = false;
                return new Descricao();
            }

            sucesso = true;
            return new Descricao(valor);
        }

        public override string ToString() =>
            Valor;

        public static implicit operator string(Descricao objeto) =>
            objeto.Valor;

        public static explicit operator Descricao(string valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}
