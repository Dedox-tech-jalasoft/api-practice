using InsuranceAPI.Application.Contracts;
using InsuranceAPI.Application.DTOs;
using InsuranceAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Application.Services
{
    public class BenefitService: IBenefitService
    {
        private readonly DatabaseContext context;

        public BenefitService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<DtoPatientBenefit>> FindPatientBenefits(int carrierId, int patientId)
        {
            IEnumerable<DtoPatientBenefit> benefits = await context.PatientsBenefits
                .Include(properties => properties.Benefit)
                .Include(properties => properties.Patient)
                .Where(properties => properties.Patient.CarrierId == carrierId 
                    && properties.Patient.Id == patientId)
                .Select(patientBenefit => new DtoPatientBenefit
                {
                    Id = patientBenefit.Benefit.Id,
                    Name = patientBenefit.Benefit.Name,
                    Description = patientBenefit.Benefit.Description,
                    Frequency = patientBenefit.Frequency,
                    IsFullCoverage = patientBenefit.IsFullCoverage
                })
                .ToListAsync();

            return benefits;
        }
    }
}
