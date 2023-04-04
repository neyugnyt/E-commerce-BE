using Core.Entiies.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_commerce_API.Extensions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services) 
        {
            var builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();

            return services;

        }
    }
}
