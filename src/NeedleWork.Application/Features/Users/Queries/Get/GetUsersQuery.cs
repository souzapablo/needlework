using MediatR;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Infrastructure.Shared;

namespace NeedleWork.Application.Features.Users.Queries.Get;

public record GetUsersQuery(string? SearchTerm,
        string? SortColumn,
        string? SortOrder,
        int Page,
        int PageSize) : IRequest<PagedList<UserViewModel>>;