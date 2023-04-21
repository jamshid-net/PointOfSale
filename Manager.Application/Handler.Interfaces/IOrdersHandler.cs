using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface IOrdersHandler
    {
        public Task<List<Order>> GetAllOrdersAsync();
        public Task<Order> GetByIdOrdersAsync(int id);
        public Task<bool> UpdateOrdersAsync(Order entity);
        public Task<bool> DeleteByIdOrdersAsync(int id);
        public Task<bool> InsertOrdersAsync(Order entity);
    }
}
