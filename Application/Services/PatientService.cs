using InsuranceAPI.Application.Contracts;
using InsuranceAPI.Application.DTOs;
using InsuranceAPI.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace InsuranceAPI.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly DatabaseContext context;

        public PatientService(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task<DtoPatient?> FindPatientById(int carrierId, int patientId)
        {
            DtoPatient? patient = await context.Patients
                .Where(patient => patient.CarrierId == carrierId)
                .Select(patient => new DtoPatient
                {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Company = patient.Company
                })
                .FirstOrDefaultAsync(patient => patient.Id == patientId);

            return patient;
        }
    }
}
