using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DataContext>(options =>
            {
                //options.UseSqlite(connectionString);
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDataContext>(provider =>
                provider.GetService<DataContext>());
            return services;
        }
    }
}
