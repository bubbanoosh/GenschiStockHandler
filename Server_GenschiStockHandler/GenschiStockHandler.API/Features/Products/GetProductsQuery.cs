using System.Collections.Generic;
using GenschiStockHandler.Dtos;
using GenschiStockHandler.Entities;
using MediatR;

namespace GenschiStockHandler.API
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductListDto>>
    {
        public string SearchText { get; set; }
    }

}