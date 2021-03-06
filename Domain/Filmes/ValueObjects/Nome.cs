﻿using Domain.Comum;
using System;

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

        public override string ToString() =>
            Valor;

        public static implicit operator string(Nome objeto) =>
            objeto.Valor;

        public static explicit operator Nome(string valor)
        {
            var resultado = Criar(valor, out var sucesso);

            if (!sucesso)
                throw new InvalidCastException($"Falha ao converter {valor}");

            return resultado;
        }
    }
}
