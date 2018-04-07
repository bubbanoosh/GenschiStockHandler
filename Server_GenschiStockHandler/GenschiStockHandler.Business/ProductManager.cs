using GenschiStockHandler.Business.Interfaces;
using GenschiStockHandler.Entities;
using GenschiStockHandler.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenschiStockHandler.Business
{
    public class ProductManager: IProductManager
    {
        IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveProduct(int id)
        {
            return _productRepository.RemoveProduct(id);
        }

        /// <summary>
        /// Get all or search products
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProducts(string searchText = "")
        {
            return await _productRepository.GetProducts(searchText);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetProductById(productId);
        }

        /// <summary>
        /// Update a product (PUT not PATCH)
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
