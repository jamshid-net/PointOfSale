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
    public class OrderProductHandler : IOrderProductHandler
    {
        private readonly IOrderProductRepository _orderProductRepository;
        public OrderProductHandler(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public async Task<bool> DeleteOrderProductByIdAsync(int id)
        {
            try
            {
                return await _orderProductRepository.DeleteByIdAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<OrderProduct>> GetAllOrderProductAsync()
        {
            try
            {
                return await _orderProductRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<OrderProduct>();
            }
        }

        public async Task<OrderProduct> GetByIdOrderProductAsync(int id)
        {
            try
            {
                return await _orderProductRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return new OrderProduct();
            }
        }

        public async Task<bool> InsertOrderProductAsync(OrderProduct orderProduct)
        {
            try
            {
                return await _orderProductRepository.InsertAsync(orderProduct);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateOrderProductAsync(OrderProduct orderProduct)
        {
            try
            {
                return await _orderProductRepository.UpdateAsync(orderProduct);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
