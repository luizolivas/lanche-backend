using Lanche.Application.Cliente.Services.Interfaces;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Cliente.Services
{
    internal class OrderService : IOrderService
    {
        public Task CreateOrderAsync(Order dto)
        {
            throw new NotImplementedException();
        }
    }
}
