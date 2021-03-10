using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Users.Data.Infrastructure;
using Users.Data.Interfaces;
using Users.Data.Model;
using Users.Domain.Services.Implementation;
using Users.Domain.Services.Interfaces;

namespace Users.API.ServicesExtension
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRepository<Person>, Repository<Person>>();
            services.AddScoped<IUnitOfWork<Person>, UnitOfWork<Person>>();
        }
    }
}
