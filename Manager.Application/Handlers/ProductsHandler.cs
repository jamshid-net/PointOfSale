using Manager.Application.Handler.Interfaces;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class ProductsHandler : IProductHandler
    {
        private readonly IProductRepository _repository;
        public ProductsHandler(IProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<bool> DeleteByIdProductAsync(int id)
        {
            try
            {
                return await _repository.DeleteByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;   
            }
          
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
            
        }

        public async Task<Product> GetByIdProductAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new Product();  
            }

           
        }

        public async Task<bool> InsertProductAsync(Product entity)
        {
            try
            {
                return await _repository.InsertAsync(entity);
            }
            catch (Exception)
            {
               return false;
            }

           
        }

        public async Task<bool> UpdateProductAsync(Product entity)
        {
            try
            {
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
