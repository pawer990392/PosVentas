using AutoMapper;
using PosVentas.Application.Dtos.Request;
using PosVentas.Application.Dtos.Response;
using PosVentas.Domain.Entities;
using PosVentas.Infrastructure.Commons.Bases.Response;
using PosVentas.Utilities.Static;

namespace PosVentas.Application.Mappers
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto,Category>();

            CreateMap<Category,CategorySelectResponseDto>()
                .ReverseMap();
        }
    }
}
