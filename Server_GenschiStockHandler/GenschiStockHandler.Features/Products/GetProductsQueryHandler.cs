using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GenschiStockHandler.Dtos;
using GenschiStockHandler.Business.Interfaces;
using GenschiStockHandler.Entities;
using MediatR;

namespace GenschiStockHandler.Features
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductListDto>>
    {
        private IProductManager _productManager;
        private IMapper _mapper;

        public GetProductsQueryHandler(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductListDto>> Handle(GetProductsQuery message, CancellationToken cancellationToken)
        {
            var products = await _productManager.GetProducts(message.SearchText);
            var productsToReturn = _mapper.Map<IEnumerable<ProductListDto>>(products);

            return productsToReturn;
        }
    }

}