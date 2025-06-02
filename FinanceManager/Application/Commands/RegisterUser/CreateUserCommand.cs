using Application.DTOs;
using MediatR;

namespace UserService.Application.Commands.RegisterUser;
public class CreateUserCommand : IRequest<UserDTO>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
