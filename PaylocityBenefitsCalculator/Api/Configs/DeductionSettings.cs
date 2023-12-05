namespace Api.Configs
{
    public class DeductionSettings
    {
        public int EmployeePaychecks { get; set; }
        public decimal EmployeeMaxDeductionSalary { get; set; }
        public double EmployeeDeductionPercentage { get; set; }
        public decimal DependentDeduction { get; set; }
        public int DependentAgeOver { get; set; }
        public decimal DependentOverDeduction { get; set; }

    }
}
