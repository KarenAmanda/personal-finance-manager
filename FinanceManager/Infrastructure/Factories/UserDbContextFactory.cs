using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using UserService.Infrastructure.Context;

namespace UserService.Infrastructure.Factories;

public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    public UserDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=finance_db;Username=postgres;Password=postgres");

        return new UserDbContext(optionsBuilder.Options);
    }
}
