﻿using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        }
    }
}
