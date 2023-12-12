using FluentValidation;
using Ordering.Application.Features.Commands.CheckoutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.CheckoutOrder
{
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.OrderName)
                .NotEmpty().WithMessage("{OrderName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{OrderName} must not exceed 50 characters.");

        }
    }
}
