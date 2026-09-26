using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using PLM.Services.Auth;

namespace PLM.Extensions.ServiceCollection;

public static class AuthorizationServiceExtensions
{
    public static IServiceCollection AddAppAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("UsuarioValido", "true")
                .Build();
        });

        services.AddScoped<IClaimsTransformation, RolAppClaimsTransformation>();

        return services;
    }
}