using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handler.Interfaces
{
    public interface IWaiterHandler
    {
        public Task<List<Waiter>> GetAllWaitersAsync();
        public Task<Waiter> GetByIdWaiterAsync(int waiterId);
        public Task<bool> UpdateWaiterAsync(Waiter waiter);
        public Task<bool> DeleteWaiterByIdAsync(int id);
        public Task<bool> InsertWaiterAsync(Waiter waiter);

    }
}
