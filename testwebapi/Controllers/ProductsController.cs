using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using testwebapi.Models;
using testwebapi.Services;

namespace testwebapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var result = await productsService.GetAllAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Results);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await productsService.GetAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            var result = await productsService.CreateAsync(product);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Update(int id, Product product)
        {
            var result = await productsService.UpdateAsync(id, product);
            if (result.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }
    }
}