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
    public class ProductsTest
    {
        public static async Task showProduct()
        {
            //IOrdersRepository orderRepository = new OrdersRepo();
            //IOrdersHandler ordersHandler = new OrdersHandler(orderRepository);
            IProductRepository productRepository = new ProductsRepo();
            IProductHandler productHandler = new ProductsHandler(productRepository);
            //var a = await productHandler.GetAllProductsAsync();
            //foreach (var product in a)
            //{
            //    Console.WriteLine(product.ProductName);

            //}

            bool isDelete = await productHandler.DeleteByIdProductAsync(3);
            Console.WriteLine(isDelete);
        }
        public static async void PoductSerchCategory(int categoryId)
        {
            ProductsRepo productsRepo = new ProductsRepo();
            var po =await productsRepo.GetAllGroupCategoryAsync(categoryId);
            foreach (var item in po)
            {
                Console.WriteLine(item.ProductName);
            }

        }
        
    }
}
