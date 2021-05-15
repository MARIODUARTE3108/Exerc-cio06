using Exercicio06.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio06.Interfaces
{
    public interface IAlunoRepository
    {
        void Inserir(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Excluir(Aluno aluno);
        List<Aluno> ObterTodos();
        Aluno ObterPorId(Guid idAluno);
    }
}
