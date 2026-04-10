using FinShark.api.Dtos.Stock;
using FinShark.api.Helpesrs;
using FinShark.api.Models;

namespace FinShark.api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> IsStockExists(int id);
    }
}
