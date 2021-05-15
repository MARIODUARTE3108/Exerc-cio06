using Exercicio06.Entities;
using Exercicio06.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio06.Controllers
{
    public class AlunoController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Exercicio06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Insetir()
        {
            try
            {
                Console.WriteLine("\n CADASTRO DE ALUNO");

                var aluno = new Aluno();

                Console.Write("INFORME O NOME DO ALUNO: ");
                aluno.Nome = Console.ReadLine();

                Console.Write("INFORME O CPF DO ALUNO: ");
                aluno.Cpf = Console.ReadLine();

                Console.Write("INFORME A MATRÍCULA DO ALUNO: ");
                aluno.Matricula = Console.ReadLine();

                Console.Write("INFORME A DATA DE NASCIMENTO DO ALUNO: ");
                aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                alunoRepository.Inserir(aluno);

                Console.WriteLine("ALUNO CADASTRADO COM SUCESSO!");
                Console.WriteLine("\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro!" + e.Message);
            }
        }

        public void Alterar()
        {
            try
            {
                Console.WriteLine("ATUALIZAÇÃO DE ALUNO");

                Console.Write("INFORME O ID DO ALUNO: ");
                var idAluno = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {
                    Console.Write("INFORME O NOME DO ALUNO: ");
                    aluno.Nome = Console.ReadLine();

                    Console.Write("INFORME O CPF DO ALUNO: ");
                    aluno.Cpf = Console.ReadLine();

                    Console.Write("INFORME A MATRÍCULA DO ALUNO: ");
                    aluno.Matricula = Console.ReadLine();

                    Console.Write("INFORME A DATA DE NASCIMENTO DO ALUNO: ");
                    aluno.DataNascimento = DateTime.Parse(Console.ReadLine());

                    alunoRepository.Atualizar(aluno);
                    Console.WriteLine("ALUNO CADASTRADO COM SUCESSO!");
                    Console.WriteLine("\n");

                }

                else
                {
                    Console.WriteLine("\n ALUNO NÃO ENCONTRADO");
                    Console.WriteLine("\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n ERRO!" + e.Message);
            }
        }

        public void Excluir()
        {
            try
            {
                Console.WriteLine("EXCLUSÃO DE ALUNO");

                Console.Write("INFORME O ID DO ALUNO: ");
                var idAluno = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {
                    alunoRepository.Excluir(aluno);

                    Console.WriteLine("ALUNO EXCLUÍDO COM SUCESSO!");
                    Console.WriteLine("\n");
                }

                else
                {
                    Console.WriteLine("ALUNO NÃO ENCONTRADO");
                    Console.WriteLine("\n");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n ERRO!" + e.Message);
            }
        }
        public void Conlsultar()
        {
            try
            {
                Console.WriteLine("CONSULTA DE ALUNOS");

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var alunos = alunoRepository.ObterTodos();

                foreach (var item in alunos)
                {
                    Console.WriteLine("ID DO ALUNO.................:" + item.IdAluno);
                    Console.WriteLine("NOME DO ALUNO...............:" + item.Nome);
                    Console.WriteLine("CPF DO ALUNO................:" + item.Cpf);
                    Console.WriteLine("MATRÍCULA DO ALUNO..........:" + item.Matricula);
                    Console.WriteLine("DATA DE NASCIMENTO DO ALUNO.:" + item.DataNascimento.ToString("ddd, dd/MM/yyyy"));
                    Console.WriteLine("-------------");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n ERRO!" + e.Message);
            }
        }



    }
}
