using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialApp.Application.Interfaces.Repositories;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Domain.Entities;
using SocialApp.Persistence.Context;
using SocialApp.Persistence.Repositories;
using SocialApp.Persistence.UnitOfWorks;

namespace SocialApp.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("*** DefaultConnection ==> ",configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<AppDbContext>( opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>),typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<User>(opt => 
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 2;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireDigit = false;
                    opt.SignIn.RequireConfirmedEmail = false;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}

