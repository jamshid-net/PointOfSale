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
    public class WaitersTest
    {
        //GetByIdWaiterAsync worked]
        public static void ZafarGetById()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Console.WriteLine(waiterHandler.GetByIdWaiterAsync(2).Result.WaiterName);
        }


        //[DeleteWaiterByIdAsync worked]
        public static void ZafarDeletedById()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Console.WriteLine(waiterHandler.DeleteWaiterByIdAsync(3).Result);
        }


        //GetAllWaitersAsync worked]
        public static async void ZafarGetAll()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            var Allwaiters = waiterHandler.GetAllWaitersAsync().Result;
            foreach(var waiter in Allwaiters)
            {
               await Console.Out.WriteLineAsync($"Name: {waiter.WaiterName} | Phone: {waiter.Phone} | Password: {waiter.Password}");
            }
        }


        //[UpdateWaiterAsync worked]
        public async static void ZafarUpdated()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Waiter waiter = new Waiter();
            waiter.WaiterName = "Quan Dale Dingle";
            waiter.Phone = "(998) 317-27-65";
            waiter.Password = "admin";
            waiter.WaiterId = 2;
            Console.WriteLine(await waiterHandler.UpdateWaiterAsync(waiter));
        }


        //[InsertWaiterAsync worked]
        public async static void ZafarIsnerted()
        {
            IWaiterRepository waiterRepo = new WaiterRepo();
            IWaiterHandler waiterHandler = new WaiterHandler(waiterRepo);
            Waiter waiter = new Waiter();
            waiter.WaiterName = "Qumalala Savesta";
            waiter.Phone = "(998) 317-27-65";   
            waiter.Password = "admin";
            Console.WriteLine(await waiterHandler.InsertWaiterAsync(waiter));
        }
    }
}
