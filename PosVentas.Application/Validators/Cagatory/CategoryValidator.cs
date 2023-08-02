using FluentValidation;
using PosVentas.Application.Dtos.Request;

namespace PosVentas.Application.Validators.Cagatory
{
    public class CategoryValidator:AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            //Nos quedamos en la cpaiturlo 8
            RuleFor(x => x.Name).NotNull().WithMessage("El campo Nombre no puede ser Nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede estar Vacio");

            RuleFor(x => x.Description).NotNull().WithMessage("El campo Descripcion no puede ser Nulo")
                .NotEmpty().WithMessage("El campo Descripcion no puede estar Vacio");
        }

    }
}
