namespace InsuranceAPI.Infrastructure.Entities
{
    public class Benefit
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<PatientBenefit> PatientsBenefits { get; set; }
    }
}
