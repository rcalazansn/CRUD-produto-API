using System;
using System.Collections.Generic;
using System.Linq;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace backend.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : Entity
    {
        public readonly ProdutoContext Context;
        public BaseRepository(ProdutoContext contexto)
        {
            Context = contexto;
        }

        public void Incluir(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
            Context.SaveChanges();
        }

        public void Editar(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Apagar(int id)
        {
            var obj = Obter(id);

            Context.Set<TEntity>().Remove(obj);
            Context.SaveChanges();
        }

        public TEntity Obter(int id)
        {
            return Context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}