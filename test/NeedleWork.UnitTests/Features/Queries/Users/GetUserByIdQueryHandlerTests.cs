using NeedleWork.Application.Features.Users.Queries.GetById;
using NeedleWork.Application.ViewModels.Users;
using NeedleWork.Core.Exceptions;

namespace NeedleWork.UnitTests.Features.Queries.Users;

public class GetUserByIdQueryHandlerTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    [Fact]
    [DisplayName("Given a valid id should return a detailed user view")]
    public async Task GivenAValidIdShouldReturnADetailedUserView()
    {
        // Given
        User user = UserFaker.GenerateUser;
        GetUserByIdQuery query = new(1);
        GetUserByIdQueryHandler queryHandler = new(_userRepository);

        _userRepository.GetByIdAsync(Arg.Any<long>())
            .Returns(user);
        
        // When
        UserDetailsViewModel result = await queryHandler.Handle(query, new CancellationToken());

        // Then
        result.Should().NotBeNull();
        result.Should().BeOfType<UserDetailsViewModel>();
        await _userRepository.Received(1)
            .GetByIdAsync(Arg.Any<long>());
    }

    [Fact]
    [DisplayName("Given an ivalid id should throw exception")]
    public async Task GivenAnInvalidIdShouldThorwException()
    {
        // Given
        GetUserByIdQuery query = new(1);
        GetUserByIdQueryHandler queryHandler = new(_userRepository);

        _userRepository.GetByIdAsync(Arg.Any<long>())
            .ReturnsNull();
        
        // When
        Func<Task> result = async () =>
            await queryHandler.Handle(query, new CancellationToken());

        // Then
        await result.Should()
            .ThrowAsync<NotFoundException>()
            .WithMessage("User with id 1 not found");
    }
}