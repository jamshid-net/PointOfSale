using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface IProductHandler
    {
        public Task<List<Product>> GetAllProductsAsync();
        public Task<Product> GetByIdProductAsync(int id);
        public Task<bool> UpdateProductAsync(Product entity);
        public Task<bool> DeleteByIdProductAsync(int id);
        public Task<bool> InsertProductAsync(Product entity);
       
    }
}
