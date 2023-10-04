using MediatR;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Exceptions;
using NeedleWork.Core.Extensions;
using NeedleWork.Core.Repositories;
using NeedleWork.Core.Services;
using NeedleWork.Core.Shared;
using NeedleWork.Infrastructure.Models;

namespace NeedleWork.Application.Features.Addresses;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, long>
{
    private readonly IUserRepository _userRepository;
    private readonly IViaCepService _viaCepService;

    public CreateAddressCommandHandler(IUserRepository userRepository, IViaCepService viaCepService)
    {
        _userRepository = userRepository;
        _viaCepService = viaCepService;

    }

    public async Task<long> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw new NotFoundException(Errors.UserNotFound(request.UserId));

        ViaCepAddress? viaCepAddress = await _viaCepService.GetAddressAsync(request.Cep);

        if (viaCepAddress is null)
            throw new NotFoundException(Errors.AddressNotFound(request.Cep));

        Address address = new AddressBuilder(viaCepAddress.Cep)
            .WithCity(viaCepAddress.City, viaCepAddress.State)
            .WithNeiborhood(viaCepAddress.Neighborhood)
            .WithStreetAndNumber(viaCepAddress.Street, request.Number)
            .Build();

        if (request.Complement is not null)
            address.Complement = request.Complement;
        
        user.AddAddress(address);

        await _userRepository.UpdateAsync(user);

        return address.Id;
    }

}