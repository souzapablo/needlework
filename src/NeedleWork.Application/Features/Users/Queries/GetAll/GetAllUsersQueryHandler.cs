using MediatR;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Core.Repositories;

namespace NeedleWork.Application.Features.Users.Queries.GetAll;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetAll();

        return users.Select(u => new UserViewModel(
            u.Id,
            u.Username,
            u.UserTag,
            u.Email,
            u.Role));
    }
}
