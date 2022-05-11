using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepareDatabase
{
    public static void PreparePopulation(IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
        }
    }

    private static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data ...");

            context.Platforms.AddRange(
                new Platform("Dot Net", "Microsoft", "Free"),
                new Platform("SQL Server Express", "Microsoft", "Free"),
                new Platform("Kubernetes", "Cloud Native Computing Foundation", "Free"),
                new Platform("Laravel", "Taylor Otwell", "Free")
            );

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }
    }
}
