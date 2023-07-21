using LocalizaME.Entity;

namespace LocalizaME.Repositories
{
    public interface IRepartidorRepository
    {
        Task<int> AddAsync(Repartidor repartidor);
        Task DeleteAsync(int id);
        Task<List<Repartidor>> GetAsync();
        Task<Repartidor?> GetAsync(int id);
        Task<int> UpdateAsync(Repartidor repartidor);
    }
}