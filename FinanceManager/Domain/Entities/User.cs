using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Common;

namespace UserService.Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; private set; } 
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    protected User() { }

    public User(Guid id, string name, string email, string passwordHash)
    {
        Id = id;
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
}
