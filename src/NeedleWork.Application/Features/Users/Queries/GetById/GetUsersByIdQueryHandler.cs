using MediatR;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Users.Queries.GetById;

public class GetUsersByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id,
            u => u.Customers,
            u => u.Orders,
            u => u.Purchases) ?? throw new Exception("User not found");

        return new UserDetailsViewModel(
            user.Id,
            user.Username,
            user.UserTag,
            user.Email,
            user.Role,
            user.Customers.Count,
            user.Orders.Count,
            user.Purchases.Count);
    }
}
