using FluentValidation;
using System.Net;

namespace Service.Dto.Validation
{
    public class CompanyValidator : AbstractValidator<CompanyDto>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("نام شرکت ضروری می باشد.")

                .NotEmpty()
                .WithMessage("نام شرکت ضروری می باشد.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.Name)
                .Length(0, 30)
                .WithMessage("نام شرکت نمی تواند بیشتر از 30 کاراکتر باشد .")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.CompanyId)
                .NotNull()
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("نام شرکت ضروری می باشد.")
                .NotNull()
                .WithMessage("نام شرکت ضروری می باشد.")
                .WithErrorCode(HttpStatusCode.BadRequest.ToString());
        }
    }
}
