using Api.Configs;
using Api.Models;
using Api.Profiles;
using Api.Query;
using Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            services.AddDbContext<EmployeeContext>(options => options.UseInMemoryDatabase(databaseName: "EmployeeDb"));
            services.AddCors(options =>
            {
                options.AddPolicy("allow localhost",
                    policy => { policy.WithOrigins("http://localhost:3000", "http://localhost"); });
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(EmployeeQuery.Handler).Assembly));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddHttpContextAccessor();
            services.AddScoped<IEmployeeDeductions, EmployeeDedutionsService>();
            services.AddScoped<IDependentDeductions, DependentDedutionsService>();
            services.AddScoped<ISalaryCalculatorService, SalaryCalculatorService>();
            AddConfigs(services, config);

            return services;
        }

        private static void AddConfigs(IServiceCollection services, IConfiguration config, Action<object> onConfigAdded = null)
        {
            void AddConfig<TConfig>(string section) where TConfig : class
            {
                var subsection = config.GetSection(section).Get<TConfig>(opts => opts.BindNonPublicProperties = true);
                services.AddSingleton(subsection);

                onConfigAdded?.Invoke(subsection);
            }

            AddConfig<DeductionSettings>("DeductionSettings");
        }
    }
}
