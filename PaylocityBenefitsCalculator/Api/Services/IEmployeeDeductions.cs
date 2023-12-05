using Api.Configs;
using Api.Models;

namespace Api.Services
{
    public interface IEmployeeDeductions
    {
        decimal GetEmployeeSalaryDeductionsPerMonth(Employee employee, DeductionSettings deductionSettings);
    }
}
