using Manager.Application.Interfaces;
using Manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Application.Repository.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
    }
}
