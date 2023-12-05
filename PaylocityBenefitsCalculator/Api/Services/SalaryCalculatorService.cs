using Api.Configs;
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

        public SalaryResults CalculateEmployeeSalary(Employee employee, DeductionSettings deductionSettings)
        {
            var employeeDeductions = Math.Round(_employeeDeductions.GetEmployeeSalaryDeductionsPerMonth(employee, deductionSettings), 2);
            var dependentDeductions = Math.Round(_dependentDeductions.GetDependentDeductionPerPayCheck(employee.Dependents.ToList(), deductionSettings));

            var salaryResult = new SalaryResults
            {
                EmployeeDeductionPerPayCheck = employeeDeductions,
                DependentsDeductionPerPayCheck = dependentDeductions,
                TotalDeductionPerPayCheck = employeeDeductions + dependentDeductions,
                DependentsYearlyDeduction = dependentDeductions * 12,
                EmployeeYearlyDeduction = employeeDeductions * 12,
                TotalYearlyDeduction = (employeeDeductions * 12) + (dependentDeductions * 12)
            };
        
            return salaryResult;
        }
    }
}
