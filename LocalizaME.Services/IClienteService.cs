using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;

namespace LocalizaME.Services
{
    public interface IClienteService
    {
        Task<BaseResponseGeneric<int>> AddAsync(ClienteDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponseGeneric<List<ClienteDtoResponse>>> GetAsync();
        Task<BaseResponseGeneric<ClienteDtoResponse>> GetAsync(int id);
        Task<BaseResponseGeneric<ClienteDtoResponse>> GetAsync(string telefono);
        Task<BaseResponse> UpdateAsync(int id, ClienteDtoRequest request);
    }
}