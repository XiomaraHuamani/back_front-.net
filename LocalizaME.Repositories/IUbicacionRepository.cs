using LocalizaME.Entity;

namespace LocalizaME.Repositories
{
    public interface IUbicacionRepository
    {
        Task<int> AddAsync(Ubicacion ubicacion);
        Task DeleteAsync(int id);
        Task<List<Ubicacion>> GetAsync();
        Task<Ubicacion?> GetAsync(int id);
        Task<int> UpdateAsync(Ubicacion ubicacion);
    }
}