using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class WaiterOrder
    {
        public int Id { get; set; }
        public Waiter Waiter { get; set; }
        public Order Order { get; set; }  
        
    }
}
