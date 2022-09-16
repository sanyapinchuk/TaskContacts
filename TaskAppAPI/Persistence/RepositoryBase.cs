using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DataContext _dataContext;
        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async void CreateAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
             _dataContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }


        public void UpdateAsync(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.Set<T>().Update(entity);

        }
    }
}
