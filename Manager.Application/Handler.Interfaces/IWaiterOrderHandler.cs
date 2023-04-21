using Manager.Application.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface IWaiterOrderHandler 
    {
        public Task<bool> DeleteByIdWaiterOrderAsync(int id);
        public Task<List<WaiterOrder>> GetAllWaiterOrderAsync();
        public Task<WaiterOrder> GetByIdWaiterOrderAsync(int id);
        public Task<bool> InsertWaiterOrderAsync(WaiterOrder entity);
        public Task<bool> UpdateWaiterOrderAsync(WaiterOrder entity);
       
    }
}
