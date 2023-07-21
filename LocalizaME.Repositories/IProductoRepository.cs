using LocalizaME.Entity;

namespace LocalizaME.Repositories
{
    public interface IProductoRepository
    {
        Task<int> AddAsync(Producto producto);
        Task DeleteAsync(int id);
        Task<List<Producto>> GetAsync();
        Task<Producto?> GetAsync(int id);
        Task<int> UpdateAsync(Producto producto);
    }
}