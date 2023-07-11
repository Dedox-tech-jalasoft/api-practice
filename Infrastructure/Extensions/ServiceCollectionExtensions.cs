using InsuranceAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<DatabaseContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("InsuranceDatabase")));    
        }
    }
}
