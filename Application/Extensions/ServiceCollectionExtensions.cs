using InsuranceAPI.Application.Contracts;
using InsuranceAPI.Application.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IBenefitService, BenefitService>();
        }
    }
}
