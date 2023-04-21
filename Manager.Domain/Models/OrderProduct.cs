using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Order: {Order}, Product: {Product}";
        }
    }
}
