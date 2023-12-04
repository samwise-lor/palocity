using Api.Query;

namespace Api.Extensions
{
    public static class CoreExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeQuery.Handler).Assembly));
            return services;
        }
    }
}
