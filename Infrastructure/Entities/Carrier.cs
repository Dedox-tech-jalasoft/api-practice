namespace InsuranceAPI.Infrastructure.Entities
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public IEnumerable<Patient> Patients { get; set; } = new List<Patient>();
    }
}
