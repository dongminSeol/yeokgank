using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using yeokgank.Repository.Region.Query;

namespace yeokgank.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // (시,군,구,동) 정보
            services.AddScoped<IRegionQuery, RegionQuery>();

            return services;
        }
    }
}
