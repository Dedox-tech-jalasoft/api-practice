using InsuranceAPI.Application.Contracts;
using InsuranceAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceAPI.Presentation.Controllers
{
    [Route("api/v1/carriers/{carrierId}/patients/{patientId}")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService) 
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientById([FromRoute] int carrierId, int patientId)
        {
            DtoPatient? patient = await patientService.FindPatientById(carrierId, patientId);

            if (patient == null)
            {
                return NotFound($"The patient with Id {patientId} is not present.");
            }

            return Ok(patient);
        }

    }
}
