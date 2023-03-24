using FluentValidation;
using NLayer.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validations
{
    public class ProductValidator:AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} doldurulmalidir.").NotEmpty().WithMessage("{PropertyName} doldurulmalidir.");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} deyeri 0-dan boyuk olmalidir.");
            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} deyeri 0-dan boyuk olmalidir.");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} deyeri 0-dan boyuk olmalidir.");
        }
    }
}
