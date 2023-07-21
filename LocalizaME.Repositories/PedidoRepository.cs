using System;
using LocalizaME.DataAccess;
using LocalizaME.Entity;
using LocalizaME.Entity.Infos;
using Microsoft.EntityFrameworkCore;

namespace LocalizaME.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly LocalizameDbContext _context;

        public PedidoRepository(LocalizameDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PedidoInfo>> GetAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            return await _context.Set<Pedido>()
                .Include(p => p.Detalles)
                .ThenInclude(p => p.Producto)
                .Where(x => x.FechaHoraPedido >= fechaInicial && x.FechaHoraPedido <= fechaFinal)
                .Select
                (
                    p => new PedidoInfo
                    { 
                        Id = p.Id,
                        FechaHoraPedido = p.FechaHoraPedido,
                        Cliente = p.RazonSocial,
                        Direccion = p.Direccion,
                        Distrito = p.Distrito,
                        Telefono = p.Telefono,
                        Latitud = p.Latitud,
                        Longitud = p.Longitud,
                        Total = p.Total,
                        Repartidor = $"{p.Repartidor.Apellidos} {p.Repartidor.Nombres}"
                    }
                )
                .ToListAsync();
        }

        public async Task<Pedido?> GetAsync(int id)
        {
            var dato = await _context.Set<Pedido>()
                .Include(p => p.Cliente)
                .Include(p => p.Repartidor)
                .Include(p => p.Detalles)
                .SingleOrDefaultAsync(p => p.Id == id);
            return dato;
        }

        public async Task<int> AddAsync(Pedido pedido)
        {
            pedido.FechaHoraPedido = DateTime.Now;
            _context.Set<Pedido>().Add(pedido);
            await _context.SaveChangesAsync();
            return pedido.Id;
        }

        public async Task<int> UpdateAsync(Pedido pedido)
        {
            pedido.FechaHoraAtencion = DateTime.Now;
            _context.Set<Pedido>().Update(pedido);
            await _context.SaveChangesAsync();
            return pedido.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await GetAsync(id);
            if (pedido == null)
            {
                return;
            }
            pedido.Status = false;
            _context.Set<Pedido>().Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}

