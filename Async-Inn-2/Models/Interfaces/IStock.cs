using JWT_D.Models.DTOs;

namespace JWT_D.Models.Interfaces
{

    public interface IStock
    {
        // CREATE
        Task<StockDTO> CreateStock(StockDTO stock);

        // GET ALL
        Task<List<StockDTO>> GetStocks();

        // GET ONE BY ID
        Task<StockDTO> GetStock(int id);
        // UPDATE
        Task<StockDTO> UpdateStock(int id, StockDTO stock);

        // DELETE
        Task DeleteStock(int id);
    }
}
