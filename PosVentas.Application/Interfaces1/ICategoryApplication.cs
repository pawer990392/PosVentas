
using PosVentas.Application.Commons1.Bases;
using PosVentas.Application.Dtos.Request;
using PosVentas.Application.Dtos.Response;
using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Commons.Bases.Response;

namespace PosVentas.Application.Interfaces1
{
    public interface ICategoryApplication
    {

        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>>ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> registerCategory(CategoryRequestDto resquestDto);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);



    }
}
