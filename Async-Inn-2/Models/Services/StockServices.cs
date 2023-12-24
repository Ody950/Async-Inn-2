using JWT_D.Data;
using JWT_D.Models.DTOs;
using JWT_D.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JWT_D.Models.Services
{
    public class StockServices : IStock
    {

        private readonly JWTDbContext _context;

        public StockServices(JWTDbContext context)
        {
            _context = context;
        }

        // CREATE........................................................................


        public async Task<StockDTO> CreateStock(StockDTO newStockDTO)
        {
            Stock stock = new Stock
            {
                ID = newStockDTO.ID,
                Name = newStockDTO.Name,
            };
            _context.Stocks.Entry(stock).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newStockDTO;
        }

        // Get Stocks........................................................................

        public async Task<List<StockDTO>> GetStocks()
        {

            var Stocks = await _context.Stocks.Select(x => new StockDTO
            {
                ID = x.ID,
                Name = x.Name,

            }).ToListAsync();

            return Stocks;
        }

        // Get Stock by ID........................................................................

        public async Task<StockDTO> GetStock(int id)
        {
            var Stocks = await _context.Stocks.Select(x => new StockDTO
            {
                ID = x.ID,
                Name = x.Name,

            }).FirstOrDefaultAsync(x => x.ID == id);

            return Stocks;
        }


        /// <summary>

        public async Task<StockDTO> UpdateStock(int id, StockDTO updateStockDTO)
        {
            Stock stock = new Stock
            {
                ID = updateStockDTO.ID,
                Name = updateStockDTO.Name,
            };
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return updateStockDTO;
        }


        // Delete Stock by ID........................................................................

        public async Task DeleteStock(int id)
        {
            Stock stock = await _context.Stocks.FindAsync(id);
            _context.Entry(stock).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
