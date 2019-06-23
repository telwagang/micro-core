using System;
using API.Interfaces;
using API.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace API.General
{
    public static class Sys
    {
       
        public static void init(IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>(); 

        }
    }
}
