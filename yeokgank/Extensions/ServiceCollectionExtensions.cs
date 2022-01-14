using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using yeokgank.Repository.Region.Query;
using yeokgank.Repository.Apartment.Query;

namespace yeokgank.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // (시,군,구,동) 정보
            services.AddScoped<IRegionQueries, RegionQueries>();
            //월별 (시,구) 아파트 실거래 거래량
            services.AddScoped<IApartmentQueries, ApartmentQueries>();
            return services;
        }
    }
}
