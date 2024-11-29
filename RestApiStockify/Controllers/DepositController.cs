using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ProducesResponseType((200), Type = typeof(List<Deposit>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Deposit>>> Get()
        {
            var deposits = await _context.Deposit.Include(a => a.Address).Include(p => p.Products).ToListAsync();
            return Ok(deposits);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Deposit))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Deposit>> Get(long id)
        {
            var deposit = await _context.Deposit.Where(a => a.Id == id).Include(a => a.Address).ToListAsync();
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
            if (address == null) return BadRequest("Address not found.");

            return Created(value: _depositBusiness.Create(deposit), uri: "");
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(DepositVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Put([FromBody] DepositVO deposit)
        {
            if (deposit == null) return BadRequest();
            return Ok(_depositBusiness.Update(deposit));
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
