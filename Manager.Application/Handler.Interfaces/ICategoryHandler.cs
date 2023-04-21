using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface ICategoryHandler
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category> GetByIdCategoryAsync(int id);
        public Task<bool> UpdateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryByIdAsync(int id);
        public Task<bool> InsertCategoryAsync(Category category);
    }
        
}
