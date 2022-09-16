using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        void CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
