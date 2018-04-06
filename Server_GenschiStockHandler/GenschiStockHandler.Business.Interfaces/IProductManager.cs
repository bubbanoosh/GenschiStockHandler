using GenschiStockHandler.Entities;
using System.Collections.Generic;

namespace GenschiStockHandler.Business.Interfaces
{
    public interface IProductManager
    {
        int AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool RemoveProduct(int id);
        IEnumerable<Product> GetProducts(string searchText);
        Product GetProductById(int id);
    }
}
