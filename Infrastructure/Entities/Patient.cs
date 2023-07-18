namespace InsuranceAPI.Infrastructure.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; } = new Carrier();
        public IEnumerable<PatientBenefit> PatientsBenefits { get; set; } = new List<PatientBenefit>();
    }
}
