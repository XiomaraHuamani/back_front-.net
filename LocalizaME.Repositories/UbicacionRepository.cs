using System;
using LocalizaME.DataAccess;
using LocalizaME.Entity;
using Microsoft.EntityFrameworkCore;

namespace LocalizaME.Repositories
{
    public class UbicacionRepository : IUbicacionRepository
    {
        private readonly LocalizameDbContext _context;

        public UbicacionRepository(LocalizameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ubicacion>> GetAsync()
        {
            return await _context.Set<Ubicacion>()
                .AsNoTracking()
                .Where(p => p.Status)
                .ToListAsync();
        }

        public async Task<Ubicacion?> GetAsync(int id)
        {
            return await _context.Set<Ubicacion>()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> AddAsync(Ubicacion ubicacion)
        {
            _context.Set<Ubicacion>().Add(ubicacion);
            await _context.SaveChangesAsync();
            return ubicacion.Id;
        }

        public async Task<int> UpdateAsync(Ubicacion ubicacion)
        {
            _context.Set<Ubicacion>().Update(ubicacion);
            await _context.SaveChangesAsync();
            return ubicacion.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var ubicacion = await GetAsync(id);
            if (ubicacion == null)
            {
                return;
            }
            ubicacion.Status = false;
            _context.Set<Ubicacion>().Update(ubicacion);
            await _context.SaveChangesAsync();
        }
    }
}

