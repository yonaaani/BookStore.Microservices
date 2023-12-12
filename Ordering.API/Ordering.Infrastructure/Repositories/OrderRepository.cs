using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
//using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Orders>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Orders>> GetOrdersByOrderName(string orderName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.OrderName == orderName)
                                .ToListAsync();
            return orderList;
        }
    }
}
