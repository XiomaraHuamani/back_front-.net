using System;
using LocalizaME.DataAccess;
using LocalizaME.Entity;
using Microsoft.EntityFrameworkCore;

namespace LocalizaME.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly LocalizameDbContext _context;

        public ProductoRepository(LocalizameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAsync()
        {
            return await _context.Set<Producto>()
                .AsNoTracking()
                .Where(p => p.Status)
                .ToListAsync();
        }

        public async Task<Producto?> GetAsync(int id)
        {
            return await _context.Set<Producto>()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> AddAsync(Producto producto)
        {
            _context.Set<Producto>().Add(producto);
            await _context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task<int> UpdateAsync(Producto producto)
        {
            _context.Set<Producto>().Update(producto);
            await _context.SaveChangesAsync();
            return producto.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await GetAsync(id);
            if (producto == null)
            {
                return;
            }
            producto.Status = false;
            _context.Set<Producto>().Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}

