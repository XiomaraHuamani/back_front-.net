using System;
using LocalizaME.DataAccess;
using LocalizaME.Entity;
using Microsoft.EntityFrameworkCore;

namespace LocalizaME.Repositories
{
    public class RepartidorRepository : IRepartidorRepository
    {
        private readonly LocalizameDbContext _context;

        public RepartidorRepository(LocalizameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Repartidor>> GetAsync()
        {
            return await _context.Set<Repartidor>()
                .AsNoTracking()
                .Where(p => p.Status)
                .ToListAsync();
        }

        public async Task<Repartidor?> GetAsync(int id)
        {
            return await _context.Set<Repartidor>()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> AddAsync(Repartidor repartidor)
        {
            _context.Set<Repartidor>().Add(repartidor);
            await _context.SaveChangesAsync();
            return repartidor.Id;
        }

        public async Task<int> UpdateAsync(Repartidor repartidor)
        {
            _context.Set<Repartidor>().Update(repartidor);
            await _context.SaveChangesAsync();
            return repartidor.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var repartidor = await GetAsync(id);
            if (repartidor == null)
            {
                return;
            }
            repartidor.Status = false;
            _context.Set<Repartidor>().Update(repartidor);
            await _context.SaveChangesAsync();
        }
    }
}

