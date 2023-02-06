namespace CodeChallenge.Models
{
    public class CompensationDTO
    {
        public CompensationDTO(Employee employee, decimal salary, string effectiveDate)
        {
            Employee = employee;
            Salary = salary;
            EffectiveDate = effectiveDate;
        }

        public Employee Employee { get; set; }
        public decimal Salary { get; set; }
        public string EffectiveDate {get; set;}
    }
}