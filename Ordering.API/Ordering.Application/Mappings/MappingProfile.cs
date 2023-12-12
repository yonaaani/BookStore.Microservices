﻿using AutoMapper;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Application.Features.Commands.UpdateOrder;
using Ordering.Application.Features.Queries.GetOrdersList;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Orders, OrdersVm>().ReverseMap();
            CreateMap<Orders, CheckoutOrderCommand>().ReverseMap();
            CreateMap<Orders, UpdateOrderCommand>().ReverseMap();
        }
    }
}
