using GenschiStockHandler.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenschiStockHandler.Repository.Interfaces
{
    public interface IProductRepository
    {
        int AddProduct(Product customer);
        bool UpdateProduct(Product customer);
        bool RemoveProduct(int id);
        Task<IEnumerable<Product>> GetProducts(string searchText);
        Task<Product> GetProductById(int id);
    }
}
