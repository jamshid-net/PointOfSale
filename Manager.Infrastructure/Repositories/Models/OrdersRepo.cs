using Dapper;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;

namespace Manager.Infrastructure.Repositories.Models
{
    public class OrdersRepo : IOrdersRepository
    {
        private readonly string _connection;
        public OrdersRepo()
        {
            _connection = GetConnection.Connection();
        }

        public async Task<bool> DeleteByIdAsync(int orderId)
        {
            if (await new OrderProductsRepo().DeleteByOrderIdAsync(orderId))
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
                {
                    await conn.OpenAsync();

                    string cmdText = @"delete from orders where order_id = @id";
                    if (await conn.ExecuteAsync(cmdText, new { id = orderId }) > 0) return true;
                    else return false;
                }
            }
            else return false;
            
        }
        public async Task<int> InsertOrderReturnId(Order order)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into orders(
                           order_table, order_date, is_completed)
                           values (@OrderTable, @OrderDate,
                           @IsCompleted) returning order_id;";

                return await conn.ExecuteScalarAsync<int>(cmdText,
                    new
                    {
                        OrderTable = order.OrderTable,
                        OrderDate = DateTime.Now,
                        IsCompleted = order.IsCompleted
                    });
            }
        }



        public async Task<List<Order>> GetAllAsync()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Order> orders = new List<Order>();
                await conn.OpenAsync();
                string cmdText = @"select * from orders;";
                var reader = await conn.ExecuteReaderAsync(cmdText);
                while (await reader.ReadAsync())
                {
                    orders.Add(new Order
                    {
                        OrderId = reader.GetInt32(0),
                        OrderTable = reader.GetInt32(1),
                        OrderDate = reader.GetDateTime(2),
                        IsCompleted = reader.GetBoolean(3)
                    });
                }

                return orders;
            }
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {

                await conn.OpenAsync();
                string cmdText = @"select * from orders where order_id = @id;";
                var reader = await conn.ExecuteReaderAsync(cmdText, new{id = orderId});
                Order orders = new Order();
                while(await reader.ReadAsync())
                {
                    orders.OrderId = reader.GetInt32(0);
                    orders.OrderTable = reader.GetInt32(1);
                    orders.OrderDate = reader.GetDateTime(2);
                    orders.IsCompleted = reader.GetBoolean(3);

                }

                return orders;
            }

        }


        public async Task<bool> InsertAsync(Order orders)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"insert into orders(
                                   order_table, order_date, is_completed)
                                   values (@OrderTable, @OrderDate,
                                   @IsCompleted);";
                if (await conn.ExecuteAsync(cmdText,
                        new
                        {
                            OrderTable = orders.OrderTable,
                            OrderDate = DateTime.Now,
                            IsCompleted = orders.IsCompleted
                        }) > 0) return true;
                else return false;
            }
        }

        public async Task<bool> UpdateAsync(Order orders)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"update orders set 
                                   order_table = @OrderTable,
                                   order_date = @OrderDate,
                                   is_completed = @IsCompleted
                                   where order_id = @OrderId;";
                if (await conn.ExecuteAsync(cmdText,
                        new
                        {
                            OrderId = orders.OrderId,
                            OrderTable = orders.OrderTable,
                            OrderDate = orders.OrderDate,
                            IsCompleted = orders.IsCompleted,
                        }) > 0) return true;
                else return false;
            }
        }
    }
}

