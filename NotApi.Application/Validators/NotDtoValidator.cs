using FluentValidation;
using NotApi.Application.Dtos;

namespace NotApi.Application.Validators
{
    public class NotDtoValidator : AbstractValidator<NotDto>
    {
        public NotDtoValidator()
        {
            RuleFor(x => x.Deger)
                .InclusiveBetween(0, 100)
                .WithMessage("Not değeri 0 ile 100 arasında olmalıdır.");

            RuleFor(x => x.Aciklama)
                .MaximumLength(250)
                .WithMessage("Açıklama en fazla 250 karakter olabilir.");
        }
    }
}
