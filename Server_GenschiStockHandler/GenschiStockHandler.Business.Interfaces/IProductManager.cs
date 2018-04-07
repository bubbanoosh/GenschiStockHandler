using GenschiStockHandler.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenschiStockHandler.Business.Interfaces
{
    public interface IProductManager
    {
        int AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool RemoveProduct(int id);
        Task<IEnumerable<Product>> GetProducts(string searchText);
        Task<Product> GetProductById(int id);
    }
}
