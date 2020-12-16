using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Filmes.Comandos.ExcluirFilme
{
    public interface IExcluirFilmeComando
    {
        bool Executar(int id);
    }
}
