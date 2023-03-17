using Hireportal.Data.Services.Abstractions;
using Hireportal.Data.Services.Concretes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyUserService, CompanyUserService>();
            services.AddScoped<ISystemParameterService, SystemParameterService>();
            services.AddScoped<ILookupTypeService, LookupTypeService>();
            services.AddScoped<IPermissionService, PermissionService>();
            var queriesAssembly = AppDomain.CurrentDomain.Load("Hireportal.Data.Management.Queries");
            var commandsAssembly = AppDomain.CurrentDomain.Load("Hireportal.Data.Management.Commands");
            services.AddMediatR(queriesAssembly, commandsAssembly);
            return services;
        }
    }
}
