namespace InsuranceAPI.Infrastructure.Entities
{
    public class PatientBenefit
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = new Patient();
        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; } = new Benefit();
        public string Frequency { get; set; } = string.Empty;
        public bool IsFullCoverage { get; set; }
    }
}
