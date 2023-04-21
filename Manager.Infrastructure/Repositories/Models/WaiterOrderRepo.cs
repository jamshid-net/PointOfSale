using Dapper;
using Manager.Application.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    public class WaiterOrderRepo : IWaiterOrderRepository
    {
        private readonly string _connection;
        public WaiterOrderRepo()
        {
            _connection = GetConnection.Connection();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
               await conn.OpenAsync();
                string cmdText = "Delete from waiter_order where id =@id";
               if( await conn.ExecuteAsync(cmdText, new {id = id})>0) return true;
               else return false;
            }
        }

        public async Task<List<WaiterOrder>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<WaiterOrder> waiterOrders = new List<WaiterOrder>();
                await conn.OpenAsync();
                string cmdText = @"select * from waiter_order";
                var reader = await conn.ExecuteReaderAsync(cmdText);
                while (reader.Read())
                {
                    waiterOrders.Add(new WaiterOrder()
                    {
                        Id = reader.GetInt32(0),
                        Waiter =await new WaiterRepo().GetByIdAsync(reader.GetInt32(1)),
                        Order = await new OrdersRepo().GetByIdAsync(reader.GetInt32(2))
                    });

                }
                return waiterOrders;    
            }
        }

        public async Task<WaiterOrder> GetByIdAsync(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                WaiterOrder waiterOrder = new();
                await conn.OpenAsync();
                string cmdText = @"select * from waiter_order where id=@id";
                var reader = await conn.ExecuteReaderAsync(cmdText, new {id = id});
                while (reader.Read())
                {
                    waiterOrder = new WaiterOrder()
                    {
                        Id = reader.GetInt32(0),
                        Waiter = await new WaiterRepo().GetByIdAsync(reader.GetInt32(1)),
                        Order = await new OrdersRepo().GetByIdAsync(reader.GetInt32(2))

                    };

                }
                return waiterOrder;
            }
        }

        public async Task<bool> InsertAsync(WaiterOrder entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into waiter_order(waiter_id,order_id) 
                                   values(@WaiterId,@OrderId)";
                if (await conn.ExecuteAsync(cmdText,
                   new
                   {
                       WaiterId = entity.Waiter.WaiterId,
                       OrderId = entity.Order.OrderId

                   }) > 0) return true;
                else return false;

            }
           
        }

        public async Task<bool> UpdateAsync(WaiterOrder entity)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update waiter_order set waiter_id=@WaiterId,
                                   order_id = @OrderId 
                                    where id = @Id";
                if (await conn.ExecuteAsync(cmdText, new
                {
                    Id = entity.Id,
                    WaiterId = entity.Waiter.WaiterId,
                    OrderId = entity.Order.OrderId
                }) > 0) return true;
                else return false;
            }
          
        }
    }
}
