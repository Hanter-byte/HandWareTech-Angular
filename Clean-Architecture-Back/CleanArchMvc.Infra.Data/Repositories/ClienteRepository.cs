using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _ClienteContext;
        public ClienteRepository(ApplicationDbContext context)
        {
            _ClienteContext = context;
        }

        public async Task<Cliente> CreateAsync(Cliente Cliente)
        {
            _ClienteContext.Cliente.Add(Cliente);
            await _ClienteContext.SaveChangesAsync();
            return Cliente;
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _ClienteContext.Cliente.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientetsAsync()
        {
            return await _ClienteContext.Cliente.ToListAsync();
        }

        public async Task<Cliente> RemoveAsync(Cliente Cliente)
        {
            _ClienteContext.Cliente.Remove(Cliente);
            await _ClienteContext.SaveChangesAsync();
            return Cliente;
        }

        public async Task<Cliente> UpdateAsync(Cliente Cliente)
        {
            _ClienteContext.Cliente.Update(Cliente);
            await _ClienteContext.SaveChangesAsync();
            return Cliente;
        }
    }
}