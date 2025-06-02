namespace UserService.Domain.Entities;
public class User 
{
    public string Name { get; private set; } 
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public bool IsDeleted { get; private set; } = false;

    private User() { }

    public static User Create(string name, string email, string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome é obrigatório.");
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("E-mail é obrigatório.");

        return new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = false
        };
    }

    public void Update(string name, string email, string passwordHash)
    {
        if (!string.IsNullOrWhiteSpace(name))
            Name = name;

        if (!string.IsNullOrWhiteSpace(email))
            Email = email;

        if (!string.IsNullOrWhiteSpace(passwordHash))
            PasswordHash = passwordHash;

        UpdatedAt = DateTime.UtcNow;

    }

    public void Delete()
    {
        if (IsDeleted) return; 

        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }


}
