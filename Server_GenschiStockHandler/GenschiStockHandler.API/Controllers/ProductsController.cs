using AutoMapper;
using GenschiStockHandler.API.Helpers;
using GenschiStockHandler.API.Dtos;
using GenschiStockHandler.Business.Interfaces;
using GenschiStockHandler.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace GenschiStockHandler.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ILogger<ProductsController> _logger;
        private IProductManager _productManager;
        private IMapper _mapper;

        public ProductsController(IProductManager productManger,
            ILogger<ProductsController> logger,
            IMapper mapper)
        {
            _productManager = productManger;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// GET: api/Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productManager.GetProducts("");
            var productsToReturn = Mapper.Map<IEnumerable<ProductListDto>>(products);

            return Ok(productsToReturn);
        }

        /// <summary>
        /// GET: api/Products/list/searchText?
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("list/{searchText?}", Name = "GetSearch")]
        public async Task<IActionResult> GetProducts(string searchText = "")
        {
            var products = await _productManager.GetProducts(searchText);
            var productsToReturn = Mapper.Map<IEnumerable<ProductListDto>>(products);

            return Ok(productsToReturn);
        }

        /// <summary>
        /// GET: api/Products/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var Product = await _productManager.GetProductById(id);

            if (Product == null)
            {
                return NotFound($"No Product found with id: {id}");
            }
            else
            {
                var productDto = Mapper.Map<ProductDetailDto>(Product);
                return Ok(productDto);
            }
        }

        /// <summary>
        /// POST: api/Products
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Product Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }

            var id = _productManager.AddProduct(Product);
            if (id <= 0)
            {
                ModelState.AddModelError(nameof(Product),
                    "Oops, Product already exists!");

                // return 422 - Unprocessable Entity
                return new UnprocessableEntityObjectResult(ModelState);
            }
            else
            {
                Product.Id = id;

                return CreatedAtRoute("Get",
                    new { id },
                    Product);
            }
        }

        /// <summary>
        /// PUT: api/Products/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }

            var productToUpdate = _productManager.GetProductById(Product.Id);

            if (productToUpdate == null)
            {
                return NotFound($"No Product found to 'Update' with id: {id}");
            }
            else
            {
                var updated = _productManager.UpdateProduct(Product);
                if (!updated)
                {
                    throw new Exception($"Product {id} could not be updated on save.");
                }

                return NoContent(); // 204 No Content
            }
        }

        /// <summary>
        /// DELETE: api/ApiWithActions/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Product = _productManager.GetProductById(id);

            if (Product == null)
            {
                return NotFound($"No Product found to 'Delete' with id: {id}");
            }
            else
            {
                if (!_productManager.RemoveProduct(id))
                {
                    throw new Exception($"Deleting Product {id} failed on save.");
                }

                _logger.LogInformation(100, $"Product {id} was DELETED!!");

                return NoContent(); // 204 No Content
            }
        }
    }
}
