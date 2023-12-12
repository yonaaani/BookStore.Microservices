using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid IDOrder { get; set; }
        public string OrderName { get; set; } = default!;
        public Guid IDBook { get; set; }
        public Guid IDDiscount { get; set; }
    }
}
