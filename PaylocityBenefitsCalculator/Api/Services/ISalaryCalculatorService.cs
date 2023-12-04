using Api.Models;

namespace Api.Services
{
    public interface ISalaryCalculatorService
    {
        SalaryResults CalculateEmployeeSalary(Employee employee);
    }
}
