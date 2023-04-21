using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface IOrderProductHandler
    {
        public Task<List<OrderProduct>> GetAllOrderProductAsync();
        public Task<OrderProduct> GetByIdOrderProductAsync(int id);
        public Task<bool> UpdateOrderProductAsync(OrderProduct orderProduct);
        public Task<bool> DeleteOrderProductByIdAsync(int id);
        public Task<bool> InsertOrderProductAsync(OrderProduct orderProduct);
    }
}
