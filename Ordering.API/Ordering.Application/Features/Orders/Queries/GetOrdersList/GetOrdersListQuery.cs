using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Queries.GetOrdersList
{
    public class GetOrdersListQuery : IRequest<List<OrdersVm>>
    {
        public string OrderName { get; set; }

        public GetOrdersListQuery(string orderName)
        {
            OrderName = orderName ?? throw new ArgumentNullException(nameof(orderName));
        }
    }
}
