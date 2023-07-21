using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;

namespace LocalizaME.Services
{
    public interface IUbicacionService
    {
        Task<BaseResponseGeneric<int>> AddAsync(UbicacionDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponseGeneric<List<UbicacionDtoResponse>>> GetAsync();
        Task<BaseResponseGeneric<UbicacionDtoResponse>> GetAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, UbicacionDtoRequest request);
    }
}