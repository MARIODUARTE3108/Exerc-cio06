using Exercicio06.Controllers;
using System;

namespace Exercicio06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**SISTEMA DE CONTROLE E CADASTRO DE ALUNO**");

            var alunoController = new AlunoController();

            Console.WriteLine("(1) CADASTRAR ALUNO");
            Console.WriteLine("(2) CONSULTAR ALUNOS");
            Console.WriteLine("(3) ATUALIZAR ALUNO");
            Console.WriteLine("(4) EXCLUIR ALUNO");
            Console.WriteLine("(0) SAIR DO SISTEMA");
            Console.WriteLine("\n");

            try
            {
                Console.Write("INFORME A OPÇÃO DESEJADA: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        alunoController.Insetir();
                        Main(args);
                        break;

                    case 2:
                        alunoController.Conlsultar();
                        Main(args);
                        break;

                    case 3:
                        alunoController.Alterar();
                        Main(args);
                        break;

                    case 4:
                        alunoController.Excluir();
                        Main(args);
                        break;

                    case 0:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n ERRO!" + e.Message);
            }

            Console.ReadKey();
        }
       
    }
    
}
