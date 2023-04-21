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
    public class WaiterOrderTest
    {
        public static void Run()
        {
            //Test();
            //Insert();
            // Update();
            Delete();
        }

        public async static void Test()
        {
            IWaiterOrderRepository waiterOrderRepository = new WaiterOrderRepo();
            IWaiterOrderHandler waiterOrdersHandler = new WaiterOrderHandlar(waiterOrderRepository);
            var ts = await waiterOrdersHandler.GetAllWaiterOrderAsync();

            foreach (var item in ts)
            {
                Console.WriteLine(item.Waiter.WaiterId);
            }
        }

        public async static void Insert()
        {
            IWaiterOrderRepository waiterOrderRepository = new WaiterOrderRepo();
            IWaiterOrderHandler waiterOrdersHandler = new WaiterOrderHandlar(waiterOrderRepository);
            WaiterOrder order = new WaiterOrder
            {
                Waiter = await new WaiterRepo().GetByIdAsync(2),
                Order = await new OrdersRepo().GetByIdAsync(3)
            };
            //    Product = await new ProductsRepo().GetByIdAsync(2)
            var te = await waiterOrdersHandler.InsertWaiterOrderAsync(order);
            Console.WriteLine(te);

        }
        public async static void Update()
        {
            IWaiterOrderRepository waiterOrderRepository = new WaiterOrderRepo();
            IWaiterOrderHandler waiterOrdersHandler = new WaiterOrderHandlar(waiterOrderRepository);
            WaiterOrder order = new WaiterOrder
            {
                Id = 10,
                Waiter = await new WaiterRepo().GetByIdAsync(1),
                Order = await new OrdersRepo().GetByIdAsync(1)
            };
            var te = await waiterOrdersHandler.UpdateWaiterOrderAsync(order);
            Console.WriteLine(te);

        }

        public async static void Delete()
        {
            IWaiterOrderRepository waiterOrderRepository = new WaiterOrderRepo();
            IWaiterOrderHandler waiterOrdersHandler = new WaiterOrderHandlar(waiterOrderRepository);
            bool re =  await waiterOrdersHandler.DeleteByIdWaiterOrderAsync(4);
            Console.WriteLine(re);
        }
    }
}
