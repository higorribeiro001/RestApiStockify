using Microsoft.AspNetCore.Mvc;
using RestApiStockify.Business;
using RestApiStockify.Data.VO;
using RestApiStockify.Model.Context;
using RestApiStockify.Model;
using Microsoft.EntityFrameworkCore;

namespace RestApiStockify.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductBusiness _productBusiness;
        private readonly EFDBContext _context;

        public ProductController(ILogger<ProductController> logger, IProductBusiness productBusiness, EFDBContext context)
        {
            _logger = logger;
            _productBusiness = productBusiness;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<Product>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var product = await _context.Product.Include(a => a.Deposit).Include(c => c.Category).ToListAsync();
            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Product))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Product>> Get(long id)
        {
            var product = await _context.Product.Where(a => a.Id == id).Include(a => a.Deposit).Include(c => c.Category).ToListAsync();
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(ProductVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromForm] ProductVO product, [FromForm] IFormFile file)
        {
            if (product == null) return BadRequest();

            var deposit = _context.Deposit.SingleOrDefault(p => p.Id == product.DepositId);
            var productsCount = _context.Product.Count(p => p.DepositId == product.DepositId);
            if (deposit == null) return BadRequest("Deposit not found.");
            if (productsCount == deposit.Limit) return BadRequest("Deposit has reached its limit.");
            
            var category = _context.Categories.SingleOrDefault(p => p.Id == product.CategoryId);
            if (category == null) return BadRequest("Category not found.");

            ProductVO detail = await _productBusiness.SaveFileToDisk(file);

            product.BlobImage = detail.DocUrl;

            return Created(value: _productBusiness.Create(product), uri: "");
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ProductVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put([FromForm] ProductVO product, [FromForm] IFormFile? file)
        {
            if (product == null) return BadRequest();

            var deposit = _context.Deposit.SingleOrDefault(p => p.Id == product.DepositId);
            if (deposit == null) return BadRequest("Deposit not found.");
            if (deposit.Products?.Count == deposit.Limit) return BadRequest("Deposit has reached its limit.");

            var category = _context.Categories.SingleOrDefault(p => p.Id == product.CategoryId);
            if (category == null) return BadRequest("Category not found.");

            if (file != null)
            {
                ProductVO detail = await _productBusiness.SaveFileToDisk(file);
                product.BlobImage = detail.DocUrl; 
            }

            return Ok(_productBusiness.Update(product));
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete(long id)
        {
            _productBusiness.Delete(id);
            return NoContent();
        }
    }
}
