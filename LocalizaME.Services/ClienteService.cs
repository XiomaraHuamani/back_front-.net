using System;
using LocalizaME.Dto.Response;
using LocalizaME.Repositories;
using Microsoft.Extensions.Logging;
using AutoMapper;
using LocalizaME.Dto.Request;

namespace LocalizaME.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ILogger<ClienteService> _logger;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, ILogger<ClienteService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<List<ClienteDtoResponse>>> GetAsync()
        {
            var response = new BaseResponseGeneric<List<ClienteDtoResponse>>();

            try
            {
                var data = await _repository.GetAsync();
                response.Data = _mapper.Map<List<ClienteDtoResponse>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<ClienteDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<ClienteDtoResponse>();

            try
            {
                var data = await _repository.GetAsync(id);
                response.Data = _mapper.Map<ClienteDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<ClienteDtoResponse>> GetAsync(string telefono)
        {
            var response = new BaseResponseGeneric<ClienteDtoResponse>();

            try
            {
                var data = await _repository.GetAsync(telefono);
                response.Data = _mapper.Map<ClienteDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(ClienteDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var data = await _repository.AddAsync(new Entity.Cliente
                {
                    RazonSocial = request.RazonSocial,
                    Telefono = request.Telefono,
                    Direccion = request.Direccion,
                    Distrito = request.Distrito,
                    Latitud = request.Latitud,
                    Longitud = request.Longitud
                });
                response.Data = data;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar AddAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ClienteDtoRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _repository.GetAsync(id);
                if (entity == null)
                {
                    response.Success = false;
                    return response;
                }
                entity.RazonSocial = request.RazonSocial;
                entity.Telefono = request.Telefono;
                entity.Direccion = request.Direccion;
                entity.Distrito = request.Distrito;
                entity.Latitud = request.Latitud;
                entity.Longitud = request.Longitud;
                await _repository.UpdateAsync(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar UpdateAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar DeleteAsync {ex.Message}");
            }

            return response;
        }
    }
}

