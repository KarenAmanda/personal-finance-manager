using Application.DTOs;
using MediatR;
using UserService.Application.Interfaces;
using UserService.Domain.Entities;

namespace UserService.Application.Commands.RegisterUser;
public class CreateUserCommandHandle : IRequestHandler<CreateUserCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandle(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserDTO> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {

        UserDTO userDto = new UserDTO();

        if (command == null)
            throw new ArgumentNullException(nameof(command), "Command is not null."); 

        if (string.IsNullOrWhiteSpace(command.Name))
            throw new ArgumentException("Name is not null.");

        if(string.IsNullOrWhiteSpace(command.Email))
            throw new ArgumentException("Email is not null.");

        if (string.IsNullOrWhiteSpace(command.PasswordHash))
            throw new ArgumentException("PasswordHash is not null.");

        var user = User.Create(command.Name, command.Email, command.PasswordHash);

       var createdUser = await _userRepository.AddUserAsync(user);

        if(createdUser == null || createdUser.Id == Guid.Empty)
            throw new InvalidOperationException("User could not be created.");

        return userDto = new UserDTO
        {
            Id = createdUser.Id,
            Name = createdUser.Name,
            Email = createdUser.Email,
            CreatedAt = createdUser.CreatedAt,
        };

    }
}
