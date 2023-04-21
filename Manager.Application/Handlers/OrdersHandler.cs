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
    public class OrdersHandler : IOrdersHandler
    {
        private readonly IOrdersRepository _repository;
        
        public OrdersHandler(IOrdersRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteByIdOrdersAsync(int id)
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

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception)
            {
               
                return new List<Order>();
            }
        }

        public async Task<Order> GetByIdOrdersAsync(int id)
        {
            try
            {
                return await _repository.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new Order();
            }
        }

        public async Task<bool> InsertOrdersAsync(Order entity)
        {
            try
            {
                return await _repository.InsertAsync(entity);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrdersAsync(Order entity)
        {
            try
            {
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
