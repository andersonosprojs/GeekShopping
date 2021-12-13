using GeekShopping.Product.API.Data.ValueObjects;
using GeekShopping.Product.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAllAsync()
        {
            var products = await _repository.FindAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindByIdAsync(long id)
        {
            var product = await _repository.FindByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateAsync(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _repository.CreateAsync(productVO);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> UpdateAsync(ProductVO productVO)
        {
            if (productVO == null)
                return BadRequest();

            var product = await _repository.UpdateAsync(productVO);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(long id)
        {
            var status = await _repository.DeleteAsync(id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
