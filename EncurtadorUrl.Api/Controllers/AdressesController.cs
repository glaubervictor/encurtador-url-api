using EncurtadorUrl.Api.Controllers.Base;
using EncurtadorUrl.Api.Shared.Interfaces.Repositories;
using EncurtadorUrl.Api.Shared.Interfaces.Services;
using EncurtadorUrl.Api.Shared.Models;
using EncurtadorUrl.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EncurtadorUrl.Api.Controllers
{
    public class AdressesController : ApiController
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressAplicationService _addressAplicationService;

        public AdressesController(
            IAddressRepository addressRepository,
            IAddressAplicationService addressAplicationService)
        {
            _addressRepository = addressRepository;
            _addressAplicationService = addressAplicationService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
            => Success(await _addressRepository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            address.SetHits();

            await _addressRepository.UpdateAsync(address);

            return Success(address);
        }

        [HttpGet("topfive")]
        public async Task<IActionResult> GetTopFive()
            => Success(await _addressRepository.GetTopFiveAsync());

        [HttpPost]
        public async Task<IActionResult> Add(AddressViewModel viewModel)
        {
            if (viewModel == null)
                return Error("Address não informado");

            var address = new Address(viewModel.Url)
                .SetHits(viewModel.Hits)
                .SetShortUrl(viewModel.ShortUrl);

            var (isValid, errors) = address.ValidationResult();
            if (!isValid)
            {
                errors.ForEach(error => Errors.Add(error.ErrorMessage));
                return Error();
            }

            if (await _addressRepository.UrlExistsAsync(address.Url))
                return Error("Url já existente na base de dados");

            await _addressRepository.AddAsync(address);
            await _addressAplicationService.SendAddressCompletedAsync(address.Url);

            return Success();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddressViewModel viewModel)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
                return Error("Address não localizado");

            address
                .SetHits(viewModel.Hits)
                .SetUrl(viewModel.Url)
                .SetShortUrl(viewModel.ShortUrl);

            var (isValid, errors) = address.ValidationResult();
            if (!isValid)
            {
                errors.ForEach(error => Errors.Add(error.ErrorMessage));
                return Error();
            }

            await _addressRepository.UpdateAsync(address);
            return Success();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);

            if (address == null)
                return Error("Address não localizado");

            await _addressRepository.DeleteAsync(id);
            return Success();
        }
    }
}
