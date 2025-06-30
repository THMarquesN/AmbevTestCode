using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class SaleProfile : Profile
    {

        public SaleProfile() {
            CreateMap<SaleRequest, CreateSaleCommand>();
            CreateMap<CreateSaleResult, SaleResponse>();
        }        
    }
}

