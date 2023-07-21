using System;
using AutoMapper;
using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;
using LocalizaME.Repositories;
using Microsoft.Extensions.Logging;

namespace LocalizaME.Services
{
    public class RepartidorService : IRepartidorService
    {
        private readonly IRepartidorRepository _repository;
        private readonly ILogger<RepartidorService> _logger;
        private readonly IMapper _mapper;

        public RepartidorService(IRepartidorRepository repository, ILogger<RepartidorService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<List<RepartidorDtoResponse>>> GetAsync()
        {
            var response = new BaseResponseGeneric<List<RepartidorDtoResponse>>();

            try
            {
                var data = await _repository.GetAsync();
                response.Data = _mapper.Map<List<RepartidorDtoResponse>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<RepartidorDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<RepartidorDtoResponse>();

            try
            {
                var data = await _repository.GetAsync(id);
                response.Data = _mapper.Map<RepartidorDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(RepartidorDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var data = await _repository.AddAsync(new Entity.Repartidor
                {
                    Apellidos = request.Apellidos,
                    Nombres = request.Nombres,
                    Telefono = request.Telefono,
                    PlacaVehiculo = request.PlacaVehiculo
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

        public async Task<BaseResponse> UpdateAsync(int id, RepartidorDtoRequest request)
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
                entity.Apellidos = request.Apellidos;
                entity.Nombres = request.Nombres;
                entity.Telefono = request.Telefono;
                entity.PlacaVehiculo = request.PlacaVehiculo;
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

