using System.Collections.Generic;
using GenschiStockHandler.Dtos;
using GenschiStockHandler.Entities;
using MediatR;

namespace GenschiStockHandler.Features
{
    public class GetProductByIdQuery : IRequest<ProductDetailDto>
    {
        public int Id { get; set; }
    }

}