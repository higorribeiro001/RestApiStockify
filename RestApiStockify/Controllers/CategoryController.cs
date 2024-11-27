using Microsoft.AspNetCore.Mvc;
using RestApiStockify.Business;
using RestApiStockify.Data.VO;

namespace RestApiStockify.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private ICategoryBusiness _categoryBusiness;

        public CategoryController(ILogger<CategoryController> logger, ICategoryBusiness categoryBusiness)
        {
            _logger = logger;
            _categoryBusiness = categoryBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<CategoryVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            return Ok(_categoryBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(CategoryVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get(long id)
        {
            var category = _categoryBusiness.FindByID(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(CategoryVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] CategoryVO category)
        {
            if (category == null) return BadRequest();
            return Ok(_categoryBusiness.Create(category));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(CategoryVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] CategoryVO category)
        {
            if (category == null) return BadRequest();
            return Ok(_categoryBusiness.Update(category));
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete(long id)
        {
            _categoryBusiness.Delete(id);
            return NoContent();
        }
    }
}
