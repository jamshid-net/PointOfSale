using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class KitchenView
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
    }
}
