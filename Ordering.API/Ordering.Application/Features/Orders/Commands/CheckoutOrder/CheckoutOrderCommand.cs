using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<Guid>
    {
        public string OrderName { get; set; } = default!;
        public Guid IDBook { get; set; }
        public Guid IDDiscount { get; set; }
    }
}
