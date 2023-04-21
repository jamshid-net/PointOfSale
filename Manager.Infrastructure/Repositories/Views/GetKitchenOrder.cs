using Dapper;
using Manager.Domain.Models;
using Manager.Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Views
{
    public class GetKitchenOrder
    {
        private readonly string _connection;
        public GetKitchenOrder()
        {
            _connection = GetConnection.Connection();
        }
        public async Task<List<KitchenView>> GetKichenViews()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<KitchenView> kitchenViews = new List<KitchenView>();
                await conn.OpenAsync();
                string cmdText = @"select order_id as OrderId,
                                   product_name as ProductName,
                                   count as ProductCount
                                   from for_trigger_product_order_view";
                kitchenViews = (await conn.QueryAsync<KitchenView>(cmdText)).ToList();
                return kitchenViews;
            }

        }
        public async Task<bool> DeleteKitchenOrder(int id)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {

                await conn.OpenAsync();
                string cmdText = @"delete from triggered_product_cart 
                                   where order_id = @orderId";
                if( await conn.ExecuteAsync(cmdText, new {orderId = id})>0)return true;
                else return false;
                    

            }
        }
        

    }
}
