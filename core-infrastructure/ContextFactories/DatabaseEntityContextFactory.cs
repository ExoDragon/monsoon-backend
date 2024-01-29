using core_infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace core_infrastructure.ContextFactories;

public class DatabaseEntityContextFactory : IDesignTimeDbContextFactory<DatabaseEntityContext>
{
    public DatabaseEntityContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<DatabaseEntityContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1434;user id=sa;password=T53wEMbsNXv7rSQZhuyaopAm4nwihk6ZR8WvqvKxL2aEKtfkdNTF3DhbymfryYa9frmm5XWmwuix3b6MgfHweJ5KNKi3ofKtrJJSNVf6fuKq4Bj3jCPjqAEQjAgdi3Qj;Database=MonsoonDatabase"
        );

        return new DatabaseEntityContext((DbContextOptions<DatabaseEntityContext>) optionsBuilder.Options);
    }
}
