using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testdata.Generator.Configuration;

namespace Testdata.Generator.DependencyInjection
{
    public static class AddDependencyInjection
    {

        public static IServiceCollection AddGenerator(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddScoped<IMyGenerator, MyGenerator>();
            services.AddOptions<SykehusGeneratorConfig>().Bind(Configuration.GetSection("SykehusGenerator"));



            services.PostConfigure<SykehusGeneratorConfig>(myOptions =>
            {
                if (myOptions.AntallPasienter> 10)
                    myOptions.AntallPasienter = 2;
            });


            return services;
        }

    }
}
