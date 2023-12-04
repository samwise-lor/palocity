using Api.Models;

namespace Api.Services
{
    public class EmployeeDedutionsService : IEmployeeDeductions
    {
        public decimal GetEmployeeSalaryPerMonth(Employee employee)
        {
            var paychecks = Constants.employeeYearlyPayChecks;
            var maxSalary = Constants.employeeMaxSalary;
            var additionalDeduction = Constants.employeeDeduction;

            if (employee.Salary == 0) return 0;            

            if ((employee.Salary/paychecks) < employee.BaseDeduction) return employee.Salary;

            return employee.Salary > maxSalary
                ? (employee.Salary / paychecks) + employee.BaseDeduction + (employee.Salary * (decimal)additionalDeduction) / 100
                : (employee.Salary / paychecks) + employee.BaseDeduction;
        }
    }
}
