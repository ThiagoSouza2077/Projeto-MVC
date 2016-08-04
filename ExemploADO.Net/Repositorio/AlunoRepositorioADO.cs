using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Dominio;
using Dominio.contrato;

namespace RepositorioADO
{
    public class AlunoRepositorioADO : IRepositorio<Aluno>
    {
        private Contexto contexto;

        private void Insert(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " Insert into ALUNO(Nome, Mae, DataNascimento) ";
            strQuery += string.Format(" Values('{0}','{1}','{2}') ",
                aluno.Nome, aluno.Mae, aluno.DataNascimento
                );
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Aluno aluno)
        {
            var strQuery = "";
            strQuery += " UPDATE ALUNO SET ";
            strQuery += string.Format(" Nome = '{0}', ", aluno.Nome);
            strQuery += string.Format(" Mae = '{0}', ", aluno.Mae);
            strQuery += string.Format(" DataNascimento = '{0}' ", aluno.DataNascimento);
            strQuery += string.Format(" WHERE Id = {0} ", aluno.Id);
            using (contexto = new Contexto())
            {
                contexto.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Aluno aluno)
        {
            if (aluno.Id > 0)
                Alterar(aluno);
            else
                Insert(aluno);
        }

        public void Excluir(Aluno aluno)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("Delete from Aluno WHERE Id = {0}", aluno.Id);
                contexto.ExecutaComando(strQuery);
            }
        }

        public IEnumerable<Aluno> ListarTodos()
        {
            using (contexto = new Contexto())
            {
                var strQuery = "Select * From Aluno";
                var retornoDataReader = contexto.ExecutarComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader);
            }
        }

        public Aluno ListarPorId(string id)
        {
            using (contexto = new Contexto())
            {
                var strQuery = string.Format("Select * From Aluno Where Id = {0}", id);
                var retornoDataReader = contexto.ExecutarComandoComRetorno(strQuery);
                return TransformaReaderEmListaDeObjeto(retornoDataReader).FirstOrDefault();
            }
        }

        private List<Aluno> TransformaReaderEmListaDeObjeto(SqlDataReader reader)
        {
            var alunos = new List<Aluno>();
            while (reader.Read())
            {
                var temObjeto = new Aluno()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Nome = reader["Nome"].ToString(),
                    Mae = reader["Mae"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString())
                };
                alunos.Add(temObjeto);
            }
            reader.Close();
            return alunos;
        }

    }
}
