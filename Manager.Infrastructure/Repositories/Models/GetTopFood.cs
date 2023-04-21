using Dapper;
using Manager.Application.BusinesLogics.Models;
using Manager.Infrastructure.Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infrastructure.Repositories.Models
{
    public class GetTopFood
    {
        private readonly string _connection;
        public GetTopFood()
        {
            _connection = GetConnection.Connection();
        }
        public async Task<List<Food>> GetTopFoods()
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
               List<Food> result = new List<Food>();  
                await conn.OpenAsync();
                string cmdText = @"select p.product_name as FoodName, 
                                    p.product_price as Price,
                                    count(p.product_name) as SoldCount
                                    from order_product op 
                                    left join products p using(product_id)  
                                    group by p.product_price ,p.product_name
                                    order by SoldCount desc limit 5;";
               result  =  (await conn.QueryAsync<Food>(cmdText)).ToList();
               return result;
             }

        }
    }
}
