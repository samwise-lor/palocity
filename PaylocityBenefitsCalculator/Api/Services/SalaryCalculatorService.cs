using Api.Models;

namespace Api.Services
{
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        private readonly IEmployeeDeductions _employeeDeductions;
        private readonly IDependentDeductions _dependentDeductions;

        public SalaryCalculatorService(IEmployeeDeductions employeeDeductions, IDependentDeductions dependentDeductions)
        {
            _employeeDeductions = employeeDeductions;
            _dependentDeductions = dependentDeductions;
        }

        public SalaryResults CalculateEmployeeSalary(Employee employee)
        {
            var employeeDeductions = Math.Round(_employeeDeductions.GetEmployeeSalaryPerMonth(employee), 2);
            var dependentDeductions = Math.Round(_dependentDeductions.GetDependentDeductionPerPayCheck(employee.Dependents.ToList()));

            var salaryResult = new SalaryResults
            {
                EmployeeDeductionPerPayCheck = employeeDeductions,
                DependentsDeductionPerPayCheck = dependentDeductions,
                TotalDeductionPerPayCheck = employeeDeductions + dependentDeductions,
                TotalYearlyDeduction = employeeDeductions * 12,
                DependentsYearlyDeduction = dependentDeductions * 12,
                EmployeeYearlyDeduction = (employeeDeductions + dependentDeductions) * 12

            };
        
            return salaryResult;
        }
    }
}
