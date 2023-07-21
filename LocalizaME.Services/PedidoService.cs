using System;
using System.Globalization;
using AutoMapper;
using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;
using LocalizaME.Repositories;
using Microsoft.Extensions.Logging;

namespace LocalizaME.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepartidorRepository _repartidorRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<PedidoService> _logger;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository repository,
            IClienteRepository clienteRepository, IRepartidorRepository repartidorRepository,
            IProductoRepository productoRepository, ILogger<PedidoService> logger, IMapper mapper)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _repartidorRepository = repartidorRepository;
            _productoRepository = productoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<ReportePedidoDtoResponse>>> GetAsync(string fechaInicial, string fechaFinal)
        {
            var response = new BaseResponseGeneric<ICollection<ReportePedidoDtoResponse>>();

            try
            {
                var culture = new CultureInfo("en-US");
                var data = await _repository.GetAsync(Convert.ToDateTime(fechaInicial, culture),
                    Convert.ToDateTime(fechaFinal, culture));
                response.Data = _mapper.Map<ICollection<ReportePedidoDtoResponse>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<PedidoDtoResponse>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<PedidoDtoResponse>();

            try
            {
                var culture = new CultureInfo("en-US");
                var data = await _repository.GetAsync(id);
                response.Data = new PedidoDtoResponse
                {
                    Id = data.Id,
                    FechaHoraPedido = Convert.ToDateTime(data.FechaHoraPedido, culture),
                    Cliente = data.RazonSocial,
                    Direccion = data.Direccion,
                    Distrito = data.Distrito,
                    Telefono = data.Telefono,
                    Latitud = data.Latitud,
                    Longitud = data.Longitud,
                    Repartidor = $"{data.Repartidor.Apellidos} {data.Repartidor.Nombres}",
                    FechaHoraAtencion = Convert.ToDateTime(data.FechaHoraAtencion, culture),
                    Total = Convert.ToDecimal(data.Total.ToString())
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar GetAsync(id) {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponseGeneric<int>> AddAsync(PedidoDtoRequest request)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var cliente = await _clienteRepository.GetAsync(request.ClienteId);
                if (cliente == null) throw new ApplicationException("Cliente no existe");

                var repartidor = await _repartidorRepository.GetAsync(request.RepartidorId);
                if (repartidor == null) throw new ApplicationException("Repartidor no existe");

                var producto = await _productoRepository.GetAsync(request.ProductoId);
                if (producto == null) throw new ApplicationException("Producto no existe");

                var entity = new Entity.Pedido
                {
                    ClienteId = cliente.Id,
                    RazonSocial = cliente.RazonSocial,
                    Direccion = cliente.Direccion,
                    Distrito = cliente.Distrito,
                    Telefono = cliente.Telefono,
                    Latitud = cliente.Latitud,
                    Longitud = cliente.Longitud,
                    RepartidorId = repartidor.Id,
                    Total = request.Cantidad * producto.Precio,
                    Detalles = new HashSet<Entity.PedidoDetalle>()
                    {
                        new Entity.PedidoDetalle
                        {
                            ProductoId = producto.Id,
                            Cantidad = request.Cantidad,
                            Precio = producto.Precio
                        }
                    }
                };

                response.Data = await _repository.AddAsync(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex, $"Error al ejecutar AddAsync {ex.Message}");
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id)
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
