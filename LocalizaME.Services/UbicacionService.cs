using System;
using AutoMapper;
using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;
using LocalizaME.Repositories;
using Microsoft.Extensions.Logging;

namespace LocalizaME.Services
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IUbicacionRepository _repository;
        private readonly ILogger<UbicacionService> _logger;
        private readonly IMapper _mapper;

        public UbicacionService(IUbicacionRepository repository, ILogger<UbicacionService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<List<UbicacionDtoResponse>>> GetAsync()
        {
            var response = new BaseResponseGeneric<List<UbicacionDtoResponse>>();

            try
            {
                var data = await _repository.GetAsync();
                response.Data = _mapper.Map<List<UbicacionDtoResponse>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<UbicacionDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<UbicacionDtoResponse>();

            try
            {
                var data = await _repository.GetAsync(id);
                response.Data = _mapper.Map<UbicacionDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(UbicacionDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var data = await _repository.AddAsync(new Entity.Ubicacion
                {
                    FechaHora = request.FechaHora,
                    RepartidorId = request.RepartidorId,
                    Telefono = request.Telefono,
                    PlacaVehiculo = request.PlacaVehiculo,
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

        public async Task<BaseResponse> UpdateAsync(int id, UbicacionDtoRequest request)
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
                entity.FechaHora = request.FechaHora;
                entity.RepartidorId = request.RepartidorId;
                entity.Telefono = request.Telefono;
                entity.PlacaVehiculo = request.PlacaVehiculo;
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

