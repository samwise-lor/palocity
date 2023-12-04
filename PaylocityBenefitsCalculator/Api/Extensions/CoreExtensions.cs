using Api.Profiles;
using Api.Query;

namespace Api.Extensions
{
    public static class CoreExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeQuery.Handler).Assembly));
            //services.AddMediatR(typeof(List.Handler));
            //services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
        }
    }
}
