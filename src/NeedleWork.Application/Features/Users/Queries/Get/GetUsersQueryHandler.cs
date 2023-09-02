using MediatR;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Core.Entities;
using NeedleWork.Core.Repositories;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Users.Queries.Get;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, PagedList<UserViewModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<PagedList<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        List<User> users = await _userRepository.GetAsync(request.SearchTerm, request.SortColumn, request.SortOrder, request.Page, request.PageSize);

        List<UserViewModel> usersViewModels = users.Select(x => new UserViewModel(
            x.Id,
            x.FullName
        )).ToList();

        return PagedList<UserViewModel>.Create(usersViewModels, request.Page, request.PageSize);
    }
}