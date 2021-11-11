using FluentValidation;
using System.Net;

namespace Service.Dto.Validation
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FullName)
                .NotNull()
                .WithMessage("نام و نام خانوادگی ضروری می باشد.")
                .NotEmpty()
                .WithMessage("نام و نام خانوادگی ضروری می باشد.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.FullName)
                .Length(0, 30)
                .WithMessage("نام و نام خانوادگی نمی تواند بیشتر از 30 کاراکتر باشد .")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.Age)
                .GreaterThan(20)
                .LessThanOrEqualTo(70)
                .WithMessage("سن کارمند باید بین 20 تا 70 باشد.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.Position)
                .NotEmpty()
                .WithMessage("موقعیت شغلی ضروری می باشد.")
                .NotNull()
                .WithMessage("موقعیت شغلی ضروری می باشد.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
