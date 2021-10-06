using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Desafio.ECommerce.Business.Models;

namespace Desafio.ECommerce.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
    }
}