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
    public class WaiterOrderHandlar : IWaiterOrderHandler
    {
        private readonly IWaiterOrderRepository _waiterOrderRepository;

        public WaiterOrderHandlar(IWaiterOrderRepository waiterOrderRepository)
        {
            this._waiterOrderRepository = waiterOrderRepository;
        }


        public async Task<bool> DeleteByIdWaiterOrderAsync(int id)
        {
            try
            {
                return await _waiterOrderRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<WaiterOrder>> GetAllWaiterOrderAsync()
        {
            try
            {
               return await _waiterOrderRepository.GetAllAsync();
            }
            catch (Exception)
            {

                return new List<WaiterOrder>();
            }
        }

        public async Task<WaiterOrder> GetByIdWaiterOrderAsync(int id)
        {
            try
            {
                return await _waiterOrderRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new WaiterOrder();
            }
        }

        public async Task<bool> InsertWaiterOrderAsync(WaiterOrder entity)
        {
            try
            {
                return await _waiterOrderRepository.InsertAsync(entity);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateWaiterOrderAsync(WaiterOrder entity)
        {
            try
            {
                return await _waiterOrderRepository.UpdateAsync(entity);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
