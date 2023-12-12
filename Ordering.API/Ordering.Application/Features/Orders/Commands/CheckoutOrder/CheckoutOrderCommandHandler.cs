
using Ordering.Domain.Entities;
using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
namespace Ordering.Application.Features.Commands.CheckoutOrder
    {
        public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, Guid>
        {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;
            private readonly ILogger<CheckoutOrderCommandHandler> _logger;

            public CheckoutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger)
            {
                _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));          
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<Guid> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
            {
                var orderEntity = _mapper.Map<Orders>(request);
                var newOrder = await _orderRepository.AddAsync(orderEntity);

                _logger.LogInformation($"Order {newOrder.IDOrder} is successfully created.");
              
                return newOrder.IDOrder;
            }

           
        }
    }

