using Lanche.Domain.Interfaces;
using Lanche.Domain.Shared.Entities;
using Lanche.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanche.Infrastructure.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Create(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
