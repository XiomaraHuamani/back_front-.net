using System;
using AutoMapper;
using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;
using LocalizaME.Repositories;
using Microsoft.Extensions.Logging;

namespace LocalizaME.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly ILogger<ProductoService> _logger;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, ILogger<ProductoService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<List<ProductoDtoResponse>>> GetAsync()
        {
            var response = new BaseResponseGeneric<List<ProductoDtoResponse>>();

            try
            {
                var data = await _repository.GetAsync();
                response.Data = _mapper.Map<List<ProductoDtoResponse>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<ProductoDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<ProductoDtoResponse>();

            try
            {
                var data = await _repository.GetAsync(id);
                response.Data = _mapper.Map<ProductoDtoResponse>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(ProductoDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var data = await _repository.AddAsync(new Entity.Producto
                {
                    Descripcion = request.Descripcion,
                    Marca = request.Marca,
                    UnidadMedida = request.UnidadMedida,
                    Precio = request.Precio
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

        public async Task<BaseResponse> UpdateAsync(int id, ProductoDtoRequest request)
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
                entity.Descripcion = request.Descripcion;
                entity.Marca = request.Marca;
                entity.UnidadMedida = request.UnidadMedida;
                entity.Precio = request.Precio;
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

