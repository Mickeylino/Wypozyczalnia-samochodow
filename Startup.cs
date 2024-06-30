using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy =>
                policy.RequireAuthenticatedUser()
                      .RequireClaim(ClaimTypes.Email, "admin@admin.pl"));
        });
    }

    // Other configurations...
}
