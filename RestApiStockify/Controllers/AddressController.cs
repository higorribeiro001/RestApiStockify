using Microsoft.AspNetCore.Mvc;
using RestApiStockify.Business;
using RestApiStockify.Data.VO;

namespace RestApiStockify.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private IAddressBusiness _addressBusiness;

        public AddressController(ILogger<AddressController> logger, IAddressBusiness addressBusiness)
        {
            _logger = logger;
            _addressBusiness = addressBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<AddressVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            return Ok(_addressBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(AddressVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get(long id)
        {
            var address = _addressBusiness.FindByID(id);
            if (address == null) return NotFound();
            return Ok(address);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(AddressVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] AddressVO address)
        {
            if (address == null) return BadRequest();
            return Ok(_addressBusiness.Create(address));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(AddressVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] AddressVO address)
        {
            if (address == null) return BadRequest();
            return Ok(_addressBusiness.Update(address));
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete(long id)
        {
            _addressBusiness.Delete(id);
            return NoContent();
        }
    }
}
