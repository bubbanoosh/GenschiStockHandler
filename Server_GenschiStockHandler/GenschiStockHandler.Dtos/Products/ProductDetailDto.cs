using System.Collections.Generic;

namespace GenschiStockHandler.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int  CategoryId { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }
}
