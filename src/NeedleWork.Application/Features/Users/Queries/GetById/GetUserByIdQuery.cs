using MediatR;
using NeedleWork.Application.ViewModels.Users;

namespace NeedleWork.Application.Features.Users.Queries.GetById;

public record GetUserByIdQuery(long Id) : IRequest<UserDetailsViewModel>;