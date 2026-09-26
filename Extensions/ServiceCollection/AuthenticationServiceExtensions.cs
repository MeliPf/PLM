using Microsoft.AspNetCore.Authentication.Negotiate;

namespace PLM.Extensions.ServiceCollection;

public static class AuthenticationServiceExtensions
{
    public static IServiceCollection AddAppAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            .AddNegotiate();

        return services;
    }
}