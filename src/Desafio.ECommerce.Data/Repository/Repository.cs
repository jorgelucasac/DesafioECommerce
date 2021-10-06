using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Desafio.ECommerce.Business.Interfaces;
using Desafio.ECommerce.Business.Models;
using Desafio.ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.ECommerce.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(AppDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}