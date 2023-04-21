using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderTable { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; } = false;

        //public override string ToString()
        //{
        //    return $"OrderId: {OrderId}, Waiter: {Waiter}, OrderTable: {OrderTable}, OrderDate: {OrderDate}, IsCompleted: {IsCompleted}";
        //}

    }
}
