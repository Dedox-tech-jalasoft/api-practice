using InsuranceAPI.Application.DTOs;

namespace InsuranceAPI.Application.Contracts
{
    public interface IPatientService
    {
        public Task<DtoPatient?> FindPatientById(int carrierId, int patientId);
    }
}
