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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDetailDto>
    {
        private IProductManager _productManager;
        private IMapper _mapper;

        public GetProductByIdQueryHandler(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<ProductDetailDto> Handle(GetProductByIdQuery message, CancellationToken cancellationToken)
        {
            var Product = await _productManager.GetProductById(message.Id);
            var productDto = _mapper.Map<ProductDetailDto>(Product);

            return productDto;
        }
    }

}