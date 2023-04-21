using Manager.Application.Handler.Interfaces;
using Manager.Application.Handlers;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Presentation.Tests
{
    public class CategoryTest
    {
        public static void Run()
        {
            RunCategories();
        }

        public async static void RunCategories()
        {
            ICategoryRepository categoryRepository = new CategoryRepo();
            ICategoryHandler categoryHandler = new CategoryHandler(categoryRepository);

            var a = await categoryHandler.GetByIdCategoryAsync(1);
            Console.WriteLine(a.CategoryName);
            //List<Category> categoryList = await categoryHandler.GetAllCategoriesAsync();
            //foreach (Category or in categoryList)
            //{
            //    Console.WriteLine(or.CategoryID);
            //}

            //read by id ishladi

            //Console.WriteLine(categoryHandler.GetByIdCategoryAsync(2).Result.CategoryName);


            //    insert ishladi
            //Category category = new()
            //{
            //    CategoryName = "Drinks"
            //};
            //bool isInsert = await categoryHandler.InsertCategoryAsync(category);
            //Console.WriteLine(isInsert);


            //  update ishladi
            //Category category = new()
            //{
            //    CategoryID=4,
            //    CategoryName = "Specials"
            //};
            //bool isUpdate = await categoryHandler.UpdateCategoryAsync(category);
            //Console.WriteLine(isUpdate);

            //categoryHandler.DeleteCategoryByIdAsync(7);

        }
    }
}
