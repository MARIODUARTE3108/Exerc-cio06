using Exercicio06.Entities;
using Exercicio06.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Exercicio06.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public string ConnectionString { get; set; }
        public void Atualizar(Aluno aluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_ALTERARALUNO",
                    new
                    { 
                        @IDALUNO = aluno.IdAluno,
                        @NOME = aluno.Nome,
                        @CPF = aluno.Cpf,
                        @MATRICULA = aluno.Matricula,
                        @DATANASCIMENTO = aluno.DataNascimento
                    }, commandType: CommandType.StoredProcedure );
            }
        }

        public void Excluir(Aluno aluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_EXCLUIRALUNO",
                    new
                    {
                        @IDALUNO = aluno.IdAluno
                    }, commandType:CommandType.StoredProcedure );

            }
        }

        public void Inserir(Aluno aluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_INSERIRALUNO",
                    new
                    {
                        @NOME = aluno.Nome,
                        @CPF = aluno.Cpf,
                        @MATRICULA = aluno.Matricula,
                        @DATANASCIMENTO = aluno.DataNascimento
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public Aluno ObterPorId(Guid idAluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Aluno>("SP_OBTERALUNOPORID",
                    new
                    {
                        @IDALUNO = idAluno
                    },commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Aluno> ObterTodos()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Aluno>("SP_CONSULTARTODOSOSALUNOS",
                    commandType: CommandType.StoredProcedure).ToList();

            }
        }
    }
}
