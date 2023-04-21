using Manager.Application.BusinesLogics.Models;
using Manager.Application.Handler.Interfaces;
using Manager.Application.Handlers;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Manager.Infrastructure.Repositories.Models;
using Manager.Presentation.Tests;
using Microsoft.Extensions.DependencyInjection;
namespace Manager.Presentation
{
    public class Program
    {
        static   void Main(string[] args)
        {

            //WaitersTest.ZafarDeletedById();
            //WaitersTest.ZafarGetAll();
            //WaitersTest.ZafarIsnerted();
            //WaitersTest.ZafarUpdated();
            //CategoryTest.RunCategories();
            // ProductsTest.showProduct().Wait();
            //OrderProductsTest.Run();
            //OrdersTest.Run(); 

            ProductsTest.showProduct();
          //  OrdersTest.Run();

            //ProductsTest.PoductSerchCategory(2);
            //  OrdersTest.Run();
            GetTopFood getTopFood = new GetTopFood();
            List<Food> a =  getTopFood.GetTopFoods().Result;
           foreach (Food food in a)
            {
                Console.WriteLine(food.FoodName);
            }
           // WaiterOrderTest.Run();
            Console.ReadKey();
        }
    }
}