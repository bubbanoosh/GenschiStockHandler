using GenschiStockHandler.Entities;
using System.Collections.Generic;

namespace GenschiStockHandler.Repository.Interfaces
{
    public interface IProductRepository
    {
        int AddProduct(Product customer);
        bool UpdateProduct(Product customer);
        bool RemoveProduct(int id);
        IEnumerable<Product> GetProducts(string searchText);
        Product GetProductById(int id);
    }
}
