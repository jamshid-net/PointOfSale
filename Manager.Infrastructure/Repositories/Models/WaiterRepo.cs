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
    public class WaiterRepo : IWaiterRepository
    {
        private readonly string _connection;
        public WaiterRepo()
        {
            _connection = GetConnection.Connection();
        }
        public async Task<bool> DeleteByIdAsync(int WaiterId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText = @"DELETE FROM waiters WHERE waiter_id = @id;";
                if(await conn.ExecuteAsync(cmdText, new{ id = WaiterId})> 0)return true;
                return false;
            }
        }
     
        public async Task<List<Waiter>> GetAllAsync()
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                List<Waiter> waiters = new List<Waiter>();
                await conn.OpenAsync();
                string cmdText =
                    @"SELECT waiter_id AS WaiterId, 
                       waiter_name AS WaiterName,
                       waiter_phone AS Phone,
                       waiter_password AS Password FROM waiters;";
                waiters = (await conn.QueryAsync<Waiter>(cmdText)).ToList();
                return waiters;
            }
        }

        public async Task<Waiter> GetByIdAsync(int waiterId)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                Waiter waiter = new Waiter();
                await conn.OpenAsync();
                string cmdText =
                    @"SELECT waiter_id AS WaiterId, 
                      waiter_name AS WaiterName,  
                      waiter_phone AS Phone,
                      waiter_password AS Password FROM waiters    
                      WHERE waiter_id = @id;";
                waiter = await conn.QueryFirstOrDefaultAsync<Waiter>(cmdText, new { id = waiterId });
                return waiter;
                
            }
        }

        public async Task<bool> InsertAsync(Waiter waiter)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection))
            {
                await conn.OpenAsync();
                string cmdText =
                    @"INSERT INTO waiters(waiter_name, waiter_phone, waiter_password)
                      VALUES (@WaiterName, @Phone, @Password);";
                if(await conn.ExecuteAsync(cmdText, waiter) > 0) return true;
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Waiter waiter)
        {
            using(NpgsqlConnection conn = new NpgsqlConnection(_connection)) 
            {
                await conn.OpenAsync();
                string cmdText =
                    @"UPDATE waiters SET waiter_name = @WaiterName,
                     waiter_phone = @Phone, waiter_password = @Password 
                     WHERE waiter_id = @WaiterId;";
                if(await conn.ExecuteAsync(cmdText, waiter) > 0) return true;
                return false;
            }
        }
    }
}
