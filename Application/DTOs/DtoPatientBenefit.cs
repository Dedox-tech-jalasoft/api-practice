namespace InsuranceAPI.Application.DTOs
{
    public class DtoPatientBenefit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public bool IsFullCoverage { get; set; } 
    }
}
