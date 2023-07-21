using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;

namespace LocalizaME.Services
{
    public interface IPedidoService
    {
        Task<BaseResponseGeneric<int>> AddAsync(PedidoDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponseGeneric<PedidoDtoResponse>> GetAsync(int id);
        Task<BaseResponseGeneric<ICollection<ReportePedidoDtoResponse>>> GetAsync(string fechaInicial, string fechaFinal);
        Task<BaseResponse> UpdateAsync(int id);
    }
}