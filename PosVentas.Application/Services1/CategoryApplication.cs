using AutoMapper;
using PosVentas.Application.Commons1.Bases;
using PosVentas.Application.Dtos.Request;
using PosVentas.Application.Dtos.Response;
using PosVentas.Application.Interfaces1;
using PosVentas.Application.Validators.Cagatory;
using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Commons.Bases.Response;
using PosVentas.Infrastructure.Persistences.Interfaces;

namespace PosVentas.Application.Services1
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidator _validatorRules;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validatorRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorRules = validatorRules;
        }

        public Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse<bool>> registerCategory(CategoryRequestDto resquestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

    }
}
