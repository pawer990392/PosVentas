using AutoMapper;
using PosVentas.Application.Commons.Bases;
using PosVentas.Application.Dtos.Request;
using PosVentas.Application.Dtos.Response;
using PosVentas.Application.Interfaces;
using PosVentas.Application.Validators.Cagatory;
using PosVentas.Domain.Entities;
using PosVentas.Infrastructure.Commons.Bases.Request;
using PosVentas.Infrastructure.Commons.Bases.Response;
using PosVentas.Infrastructure.Persistences.Interfaces;
using PosVentas.Utilities.Static;

namespace PosVentas.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {

         private readonly IUnitOfWork _unitOfWork;
         private readonly IMapper _mapper;
         private readonly CategoryValidator _validationRules;

        public CategoryApplication(IUnitOfWork unitOfWork, IMapper mapper, CategoryValidator validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryResponseDto>>();
            var categories = _unitOfWork.Category.ListCategories(filters);

            //validadar que esta categorias nos ea nulos
            if (categories is not null)
            {
                response.IsSuccess= true;
                //responder la data con uso de _mapper para mapear
                response.Data=_mapper.Map<BaseEntityResponse<CategoryResponseDto>>(categories);
                //retornamos el mesaaje
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPATY;
            }
            return response;
        }
        public async Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategories()
        {
            var response = new BaseResponse<IEnumerable<CategorySelectResponseDto>>();
            var categories= await _unitOfWork.Category.ListSelectCategories();

            if(categories is not null)
            {
                response.IsSuccess= true;
                response.Data = _mapper.Map<IEnumerable<CategorySelectResponseDto>>(categories);
                response.Message= ReplyMessage.MESSAGE_QUERY;

            }
            else
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPATY;

            }
            return response;

        }

        public async Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId)
        {
            var response = new BaseResponse<CategoryResponseDto>();
            var category=await _unitOfWork.Category.CategoryById(categoryId);

            if(category is not null)
            {

                response.IsSuccess= true;
                response.Data = _mapper.Map<CategoryResponseDto>(category);
                response.Message=ReplyMessage.MESSAGE_QUERY;

            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPATY;

            }
            return response;
        }

        public async Task<BaseResponse<bool>> registerCategory(CategoryRequestDto resquestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationRules.ValidateAsync(resquestDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors=validationResult.Errors;
                return response;
            }
            var category=_mapper.Map<Category>(resquestDto);
            response.Data=await _unitOfWork.Category.RegisterCategory(category);

            if (response.Data)
            {
                response.IsSuccess= true;
                response.Message = ReplyMessage.MESSAGE_SAVE;

            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }   


        public async Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var categoryEdit = await CategoryById(categoryId);

            if(categoryEdit.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPATY;

            }

            var category = _mapper.Map<Category>(requestDto);
            category.CategoryId = categoryId;

            response.Data=await _unitOfWork.Category.EditCategory(category);

            if(response.Data)
            {

                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message= ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
     
        public async Task<BaseResponse<bool>> RemoveCategory(int categoryId)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(categoryId);

            if(category.Data is null)
            {
                response.IsSuccess= false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPATY;

            }
            response.Data = await _unitOfWork.Category.RemoveCategory(categoryId);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;

            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;

        }
    }
}
