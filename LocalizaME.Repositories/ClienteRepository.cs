using System;
using LocalizaME.DataAccess;
using LocalizaME.Entity;
using Microsoft.EntityFrameworkCore;

namespace LocalizaME.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocalizameDbContext _context;

        public ClienteRepository(LocalizameDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAsync()
        {
            return await _context.Set<Cliente>()
                .AsNoTracking()
                .Where(p => p.Status)
                .ToListAsync();
        }

        public async Task<Cliente?> GetAsync(int id)
        {
            return await _context.Set<Cliente>()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cliente> GetAsync(string telefono)
        {
            return await _context.Set<Cliente>()
                .OrderBy(x => x.Telefono)
                .FirstOrDefaultAsync(p => p.Telefono.StartsWith(telefono));
        }

        public async Task<int> AddAsync(Cliente cliente)
        {
            _context.Set<Cliente>().Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task<int> UpdateAsync(Cliente cliente)
        {
            _context.Set<Cliente>().Update(cliente);
            await _context.SaveChangesAsync();
            return cliente.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await GetAsync(id);
            if (cliente == null)
            {
                return;
            }
            cliente.Status = false;
            _context.Set<Cliente>().Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}

