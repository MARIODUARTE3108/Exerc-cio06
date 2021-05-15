using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio06.Entities
{
    public class Aluno
    {
        public Guid IdAluno { get; set; }
        public String Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
