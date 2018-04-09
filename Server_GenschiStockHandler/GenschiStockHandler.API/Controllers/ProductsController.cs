using AutoMapper;
using GenschiStockHandler.API.Helpers;
using GenschiStockHandler.Business.Interfaces;
using GenschiStockHandler.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using MediatR;
//using GenschiStockHandler.Features;
using GenschiStockHandler.Dtos;

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
        private IMediator _mediator;

        public ProductsController(IMediator mediator,
            IProductManager productManger,
            ILogger<ProductsController> logger,
            IMapper mapper)
        {
            _mediator = mediator;
            _productManager = productManger;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// GET: api/Products/list/searchText?
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("list/{searchText?}", Name = "GetSearch")]
        public async Task<IActionResult> GetProducts(string searchText = "")
        {
            var productsToReturn = await _mediator.Send(new GetProductsQuery { SearchText = searchText });

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
            var productDetailDto = await _mediator.Send(new GetProductByIdQuery { Id = id});

            if (productDetailDto == null)
            {
                return NotFound($"No Product found with id: {id}");
            }
            else
            {
                return Ok(productDetailDto);
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
                    "Hmmm, Product insert failed?");

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
