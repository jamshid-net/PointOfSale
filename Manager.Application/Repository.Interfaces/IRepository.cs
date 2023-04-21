using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteByIdAsync(int id);
        public Task<bool> InsertAsync(T entity);
    }
}
