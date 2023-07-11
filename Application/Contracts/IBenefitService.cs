using InsuranceAPI.Application.DTOs;

namespace InsuranceAPI.Application.Contracts
{
    public interface IBenefitService
    {
        public Task<IEnumerable<DtoPatientBenefit>> FindPatientBenefits(int carrierId, int patientId); 
    }
}
