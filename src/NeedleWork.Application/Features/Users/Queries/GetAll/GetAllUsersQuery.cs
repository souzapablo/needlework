using MediatR;
using NeedleWork.Application.ViewModels.Users;

namespace NeedleWork.Application.Features.Users.Queries.GetAll;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserViewModel>>;
