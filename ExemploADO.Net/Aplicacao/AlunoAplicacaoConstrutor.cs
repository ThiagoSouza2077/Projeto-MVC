using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using RepositorioADO;
using RepositorioEF;

namespace Aplicacao
{
    public class AlunoAplicacaoConstrutor
    {
        public static AlunoAplicacao AlunoAplicacaoADO()
        {
            return new AlunoAplicacao(new AlunoRepositorioADO());
        }

        public static AlunoAplicacao AlunoAplicacaoEF()
        {
            return new AlunoAplicacao(new AlunoRepositorioEF());
        }

    }
}
