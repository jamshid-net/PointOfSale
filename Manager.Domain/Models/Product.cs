using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
       // [ForeignKey("Category")]
        public Category Category { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductDescription { get; set;}
        public string? ProductPicture { get; set; } 
    }
}
