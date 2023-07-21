using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;

namespace LocalizaME.Services
{
    public interface IRepartidorService
    {
        Task<BaseResponseGeneric<int>> AddAsync(RepartidorDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponseGeneric<List<RepartidorDtoResponse>>> GetAsync();
        Task<BaseResponseGeneric<RepartidorDtoResponse>> GetAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, RepartidorDtoRequest request);
    }
}