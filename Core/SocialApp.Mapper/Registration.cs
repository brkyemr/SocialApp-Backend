using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SocialApp.Application.Interfaces.AutoMapper;

namespace SocialApp.Mapper
{
    public static class Registration
    {

        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,AutoMapper.Mapper>();
        }
    }
}