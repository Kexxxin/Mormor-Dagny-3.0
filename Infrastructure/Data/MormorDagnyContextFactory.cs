using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class MormorDagnyContextFactory : IDesignTimeDbContextFactory<MormorDagnyContext>
{
    public MormorDagnyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MormorDagnyContext>();

        var cs = "server=localhost;database=MormorDagny;user=root;password=Majasam12345;";

        optionsBuilder.UseMySql(cs, ServerVersion.AutoDetect(cs));

        return new MormorDagnyContext(optionsBuilder.Options);
    }
}
