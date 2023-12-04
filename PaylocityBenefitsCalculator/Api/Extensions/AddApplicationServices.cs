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
            //services.AddMediatR(typeof(List.Handler));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddHttpContextAccessor();
            services.AddScoped<IEmployeeDeductions, EmployeeDedutionsService>();
            services.AddScoped<IDependentDeductions, DependentDedutionsService>();
            services.AddScoped<ISalaryCalculatorService, SalaryCalculatorService>();

            return services;
        }
    }
}
