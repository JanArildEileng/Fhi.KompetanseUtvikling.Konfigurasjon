using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testdata.Generator.DependencyInjection
{
    public static class AddDependencyInjection
    {

        public static IServiceCollection AddGenerator(this IServiceCollection services)
        {
            services.AddScoped<IMyGenerator, MyGenerator>();

            return services;
        }

    }
}
