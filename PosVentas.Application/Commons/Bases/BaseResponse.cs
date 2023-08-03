using FluentValidation.Results;

namespace PosVentas.Application.Commons.Bases
{
    public class BaseResponse<T>
    {
        //uan clases que devuelve la respuesta del sistemas hacia un framworok
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
