using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Testdata.Generator.Configuration;
using Testdata.Generator.SykehusGeneratorer;

namespace Testdata.Generator.DependencyInjection
{
    public static class AddDependencyInjection
    {
        public static IServiceCollection AddGenerator(this IServiceCollection services,IConfiguration Configuration)
        {
            services.AddScoped<IMyGenerator, MyGenerator>();
            services.AddOptions<SykehusGeneratorConfig>().Bind(Configuration.GetSection("SykehusGenerator"));
            services.AddOptions<PasientGeneratorConfig>().Bind(Configuration.GetSection("SykehusGenerator").GetSection("PasientGenerator"));
            services.AddOptions<SykdomGeneratorConfig>().Bind(Configuration.GetSection("SykehusGenerator").GetSection("PasientGenerator").GetSection("SykdomGenerator"));

            services.AddSingleton<SykehusGenerator>();
            services.AddSingleton<PasientGenerator>();
            services.AddSingleton<SykdomGenerator>();

            services.PostConfigure<SykehusGeneratorConfig>(myOptions =>
            {
                if (myOptions.AntallPasienter> 10)
                    myOptions.AntallPasienter = 2;
            });

            return services;
        }

    }
}
