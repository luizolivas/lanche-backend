using Lanche.Application.DTOs.Cliente;
using Lanche.Application.Interfaces;
using Lanche.Domain.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Services
{
    internal class OrderService : IOrderService
    {
        public Task CreateOrderAsync(CreateOrderDto dto)
        {
            Order order = new Order
            {

            };

            return Task.CompletedTask;
        }
    }
}
