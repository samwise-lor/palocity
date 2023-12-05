using Api.Configs;
using Api.Models;

namespace Api.Services
{
    public interface ISalaryCalculatorService
    {
        SalaryResults CalculateEmployeeSalary(Employee employee, DeductionSettings deductionSettings);
    }
}
