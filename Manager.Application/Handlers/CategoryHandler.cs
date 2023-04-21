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
    public class CategoryHandler: ICategoryHandler 
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        public async Task<bool> DeleteCategoryByIdAsync(int id)
        {
            try
            {
                return await _categoryRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            try
            {
                return await _categoryRepository.GetAllAsync();
            }
            catch (Exception)
            {
                return new List<Category>();
            }
        }

        public async Task<Category> GetByIdCategoryAsync(int id)
        {
            try
            {
                return await _categoryRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new Category();
            }
        }

        public async Task<bool> InsertCategoryAsync(Category category)
        {
            try
            {
                return await _categoryRepository.InsertAsync(category);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            try
            {
                return await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
