namespace PosVentas.Application.Commons1.Bases

using FluentValidation.Results;
using System.Collections.Generic;
public class BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }

        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
