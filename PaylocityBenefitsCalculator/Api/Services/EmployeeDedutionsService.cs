using Api.Configs;
using Api.Models;

namespace Api.Services
{
    public class EmployeeDedutionsService : IEmployeeDeductions
    {
        public decimal GetEmployeeSalaryDeductionsPerMonth(Employee employee, DeductionSettings deductionSettings)
        {
            var paychecks = deductionSettings.EmployeePaychecks;
            var maxSalary = deductionSettings.EmployeeMaxDeductionSalary;
            var additionalDeduction = deductionSettings.EmployeeDeductionPercentage;


            if (employee.Salary == 0) return 0;            

            if ((employee.Salary/paychecks) < employee.BaseDeduction) return employee.Salary;            

            return employee.Salary > maxSalary
            ? (employee.BaseDeduction + ((employee.Salary * (decimal)additionalDeduction) / 100))
            : employee.BaseDeduction;
        }
    }
}
