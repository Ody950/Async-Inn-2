using JWT_D.Models.DTOs;
using JWT_D.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_D.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStock _stock;

        public StocksController(IStock stock)
        {
            _stock = stock;
        }


        // GET: api/Stocks
        [Authorize(Roles = "Manager")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockDTO>>> GetStocks()
        {
            var stocks = await _stock.GetStocks();
            return Ok(stocks);
        }

        // GET: api/Stocks/5
        [Authorize(Roles = "Manager")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<StockDTO>> GetStock(int id)
        {
            StockDTO TheStock = await _stock.GetStock(id);

            if (TheStock == null)
            {
                return NotFound();
            }

            return TheStock;
        }

        // PUT: api/Stocks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock(int id, StockDTO stock)
        {
            if (id != stock.ID)
            {
                return BadRequest();
            }
            var updateStock = await _stock.UpdateStock(id, stock);
            return Ok(updateStock);
        }

        // POST: api/Stocks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<ActionResult<StockDTO>> PostStock(StockDTO stock)
        {
            if (stock == null)
            {
                return Problem("Entity set 'JWTDbContext.Stocks'  is null.");
            }
            var newStock = await _stock.CreateStock(stock);

            return Ok(newStock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await _stock.DeleteStock(id);
            return NoContent();
        }


    }
}
