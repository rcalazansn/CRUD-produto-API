using System;
using System.Collections.Generic;
using backend.Models;

namespace backend.Repositories
{
public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        void Incluir(TEntity obj);
        void Editar(TEntity obj);
        void Apagar(int id);
        TEntity Obter(int id);
        IEnumerable<TEntity> ObterTodos();
    }
}