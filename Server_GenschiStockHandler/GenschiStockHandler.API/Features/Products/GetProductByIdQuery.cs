using System.Collections.Generic;
using GenschiStockHandler.Dtos;
using GenschiStockHandler.Entities;
using MediatR;

namespace GenschiStockHandler.API
{
    public class GetProductByIdQuery : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
    }

}