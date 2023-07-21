using LocalizaME.Entity;

namespace LocalizaME.Repositories
{
    public interface IClienteRepository
    {
        Task<int> AddAsync(Cliente cliente);
        Task DeleteAsync(int id);
        Task<List<Cliente>> GetAsync();
        Task<Cliente?> GetAsync(int id);
        Task<Cliente?> GetAsync(string telefono);
        Task<int> UpdateAsync(Cliente cliente);
    }
}