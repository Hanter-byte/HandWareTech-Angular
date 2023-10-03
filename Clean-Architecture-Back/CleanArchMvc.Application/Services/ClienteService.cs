using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class Clienteervice : IClienteervice
    {
        private IClienteRepository _ClienteRepository;
        private IMapper _mapper;
        public Clienteervice(IClienteRepository ClienteRepository, IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
        }

        public async Task Add(ClienteDTO ClienteDTO)
        {
            var Cliententity = _mapper.Map<Cliente>(ClienteDTO);
            await _ClienteRepository.CreateAsync(Cliententity);
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            var Cliententity = await _ClienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteDTO>(Cliententity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetCliente()
        {
            var Cliententity = await _ClienteRepository.GetClientetsAsync();
            return _mapper.Map<IEnumerable<ClienteDTO>>(Cliententity);
        }

        public async Task Remove(int id)
        {
            var Cliententity = _ClienteRepository.GetByIdAsync(id).Result;
            await _ClienteRepository.RemoveAsync(Cliententity);
        }

        public async Task Update(ClienteDTO Cliente)
        {
            var Cliententity = _mapper.Map<Cliente>(Cliente);
            await _ClienteRepository.UpdateAsync(Cliententity);
        }
    }
}