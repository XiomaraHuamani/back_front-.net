using LocalizaME.Entity;
using LocalizaME.Entity.Infos;

namespace LocalizaME.Repositories
{
    public interface IPedidoRepository
    {
        Task<int> AddAsync(Pedido pedido);
        Task DeleteAsync(int id);
        Task<ICollection<PedidoInfo>> GetAsync(DateTime fechaInicial, DateTime fechaFinal);
        Task<Pedido?> GetAsync(int id);
        Task<int> UpdateAsync(Pedido pedido);
    }
}