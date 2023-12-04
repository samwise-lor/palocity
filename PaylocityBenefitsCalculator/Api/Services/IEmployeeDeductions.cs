using Api.Models;

namespace Api.Services
{
    public interface IEmployeeDeductions
    {
        decimal GetEmployeeSalaryPerMonth(Employee employee);
    }
}
