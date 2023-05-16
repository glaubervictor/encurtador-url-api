using EncurtadorUrl.Api.Shared.Models;
using FluentValidation;

namespace EncurtadorUrl.Api.Shared.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty()
                .WithMessage("O campo Url é requerido");

            RuleFor(x => x.ShortUrl)
                .NotEmpty()
                .WithMessage("O campo Short Url é requerido");
        }
    }
}
