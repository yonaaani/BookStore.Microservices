using FluentValidation;
using Ordering.Application.Features.Commands.UpdateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(p => p.OrderName)
               .NotEmpty().WithMessage("{OrderName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{OrderName} must not exceed 50 characters.");

        }
    }
}
