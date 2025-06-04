using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task Create(Order order);
    }
}
