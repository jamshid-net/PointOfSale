using Manager.Application.Handler.Interfaces;
using Manager.Application.Repository.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Handlers
{
    public class WaiterHandler : IWaiterHandler
    {
        private readonly IWaiterRepository _repository;

        public WaiterHandler(IWaiterRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteWaiterByIdAsync(int id)
        {
            try
            {
                return await _repository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                return false;
            }  
        }

        public async Task<List<Waiter>> GetAllWaitersAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception)
            {
                return new List<Waiter>();
            }
        }

        public async Task<Waiter> GetByIdWaiterAsync(int waiterId)
        {
            try
            {
                return await _repository.GetByIdAsync(waiterId);
            }
            catch (Exception)
            {

                return new Waiter();
            }
                
            
            
        }

        public async Task<bool> InsertWaiterAsync(Waiter waiter)
        {
            try
            {
                return await _repository.InsertAsync(waiter);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateWaiterAsync(Waiter waiter)
        {
            try
            {
                return await _repository.UpdateAsync(waiter);
            }
            catch (Exception) 
            { 
                return false;
            }
        }
    }
}
