using LocalizaME.Dto.Request;
using LocalizaME.Dto.Response;

namespace LocalizaME.Services
{
    public interface IProductoService
    {
        Task<BaseResponseGeneric<int>> AddAsync(ProductoDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
        Task<BaseResponseGeneric<List<ProductoDtoResponse>>> GetAsync();
        Task<BaseResponseGeneric<ProductoDtoResponse>> GetAsync(int id);
        Task<BaseResponse> UpdateAsync(int id, ProductoDtoRequest request);
    }
}