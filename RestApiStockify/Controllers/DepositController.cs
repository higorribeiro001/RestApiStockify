using Microsoft.AspNetCore.Mvc;
using RestApiStockify.Business;
using RestApiStockify.Data.VO;
using RestApiStockify.Model;
using RestApiStockify.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace RestApiStockify.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class DepositController : ControllerBase
    {
        private readonly ILogger<DepositController> _logger;
        private IDepositBusiness _depositBusiness;
        private readonly EFDBContext _context;

        public DepositController(ILogger<DepositController> logger, IDepositBusiness depositBusiness, EFDBContext context)
        {
            _logger = logger;
            _depositBusiness = depositBusiness;
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<DepositVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            return Ok(_depositBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(DepositVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get(long id)
        {
            var deposit = _depositBusiness.FindByID(id);
            if (deposit == null) return NotFound();
            return Ok(deposit);
        }

        [HttpPost]
        [ProducesResponseType((201), Type = typeof(DepositVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] DepositVO deposit)
        {
            if (deposit == null) return BadRequest();

            var address = _context.Address.SingleOrDefault(p => p.Id == deposit.AddressId);
            if (address == null) return NotFound("Address not found.");

            return Ok(_depositBusiness.Create(deposit));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(DepositVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] DepositVO address)
        {
            if (address == null) return BadRequest();
            return Ok(_depositBusiness.Update(address));
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete(long id)
        {
            _depositBusiness.Delete(id);
            return NoContent();
        }
    }
}
