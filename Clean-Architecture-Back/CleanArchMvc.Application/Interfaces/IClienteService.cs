using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IClienteervice
    {
        Task<IEnumerable<ClienteDTO>> GetCliente();
        Task<ClienteDTO> GetById(int id);
        Task Add(ClienteDTO ClienteDTO);
        Task Update(ClienteDTO Cliente);
        Task Remove(int id);
    }
}