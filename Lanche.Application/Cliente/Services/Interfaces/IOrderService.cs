using Lanche.Application.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Application.Cliente.Services.Interfaces
{
    internal interface IOrderService
    {
        Task CreateOrderAsync(CreateOrderDto dto);
    }
}
