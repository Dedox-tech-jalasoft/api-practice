using InsuranceAPI.Application.Contracts;
using InsuranceAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPI.Presentation.Controllers
{
    [Route("api/v1/carriers/{carrierId}/patients/{patientId}/benefits")]
    [ApiController]
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitService benefitService;

        public BenefitsController(IBenefitService benefitService)
        {
            this.benefitService = benefitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientBenefits([FromRoute] int carrierId, int patientId)
        {
            IEnumerable<DtoPatientBenefit> patientBenefits = await benefitService
                .FindPatientBenefits(carrierId, patientId);
            
            return Ok(patientBenefits);
        }
    }
}
