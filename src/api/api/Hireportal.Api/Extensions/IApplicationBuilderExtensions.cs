using Hireportal.Api.Middleware;

namespace Hireportal.Api.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseClaims(this IApplicationBuilder app)
        {
            app.UseMiddleware<ClaimSetupMiddleware>();

        }
    }
}
