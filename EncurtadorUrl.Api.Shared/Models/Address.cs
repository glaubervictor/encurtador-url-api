using EncurtadorUrl.Api.Shared.Extensions;
using EncurtadorUrl.Api.Shared.Validators;
using FluentValidation.Results;

namespace EncurtadorUrl.Api.Shared.Models
{
    public class Address
    {
        public int Id { get; private set; }
        public int Hits { get; private set; }
        public string Url { get; private set; }
        public string ShortUrl { get; private set; }

        private Address() { }

        public Address(string url)
        {
            Url = url;
        }

        public Address SetHits(int hits = 0)
        {
            Hits = hits == 0 ? Hits += 1 : hits;
            return this;
        }

        public Address SetUrl(string url)
        {
            Url = url;
            return this;
        }

        public Address SetShortUrl(string shortUrl = null)
        {
            ShortUrl = string.IsNullOrEmpty(shortUrl) ? GenericExtensions.GenerateShortUrl() : shortUrl;
            return this;
        }

        public (bool isValid, List<ValidationFailure> errors) ValidationResult()
        {
            var validatorResult = new AddressValidator().Validate(this);
            return (validatorResult.IsValid, validatorResult.Errors);
        }
    }
}
