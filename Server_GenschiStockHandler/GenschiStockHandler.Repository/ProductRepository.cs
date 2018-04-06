using GenschiStockHandler.Entities;
using GenschiStockHandler.Repository.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static System.Data.CommandType;

using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;

namespace GenschiStockHandler.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly IConfiguration _config;

        public ProductRepository(IConfiguration config) : base(config)
        {
            _config = config;

        }

        /// <summary>
        /// Add a new Product to the Database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int AddProduct(Product product)
        {
            try
            {
                return 1;
                // using (var connection = GetOpenConnection())
                // {
                //     DynamicParameters parameters = new DynamicParameters();
                //     parameters.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //     parameters.Add("@FirstName", product.FirstName);
                //     parameters.Add("@LastName", product.LastName);
                //     parameters.Add("@Email", product.Email);
                //     SqlMapper.Execute(connection, "Products_AddProduct", param: parameters, commandType: StoredProcedure);

                //     int id = parameters.Get<int>("Id");

                //     return id;
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Completetly remove a Product fron the Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool RemoveProduct(int id)
        {
            return true;
            // using (var connection = GetOpenConnection())
            // {
            //     DynamicParameters parameters = new DynamicParameters();
            //     parameters.Add("@Id", id);
            //     SqlMapper.Execute(connection, "Products_DeleteProduct", param: parameters, commandType: StoredProcedure);
            //     return true;
            // }
        }

        /// <summary>
        /// Gets either the full list or performs a basic Name or email search
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(string searchText = "")
        {
            using (var connection = GetOpenConnection())
            {
                return connection.GetAll<Product>();
            }
        }

        /// <summary>
        /// Gets a Product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product GetProductById(int productId)
        {
            try
            {
                using (var connection = GetOpenConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@ProductId", productId);

                    string sql = @" 
                        select *
                        from products
                        where id = @ProductId";

                    var product = SqlMapper.Query<Product>(connection, sql, param: parameters).FirstOrDefault()   ;                     

                    return product;

                    //return connection.Get<Product>(productId);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProduct(Product product)
        {
            return true;
            // try
            // {
            //     using (var connection = GetOpenConnection())
            //     {
            //         DynamicParameters parameters = new DynamicParameters();
            //         parameters.Add("@Id", product.Id);
            //         parameters.Add("@FirstName", product.FirstName);
            //         parameters.Add("@LastName", product.LastName);
            //         parameters.Add("@Email", product.Email);
            //         SqlMapper.Execute(connection, "Products_UpdateProduct", param: parameters, commandType: StoredProcedure);
            //         return true;
            //     }
            // }
            // catch (Exception ex)
            // {
            //     throw ex;
            // }
        }
    }
}