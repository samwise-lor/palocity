using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class GetEmployeeSalaryDto
    {
        public decimal TotalDeductionPerPayCheck { get; set; }
        public decimal DependentsDeductionPerPayCheck { get; set; }
        public decimal EmployeeDeductionPerPayCheck { get; set; }
        public decimal TotalYearlyDeduction { get; set; }
        public decimal DependentsYearlyDeduction { get; set; }
        public decimal EmployeeYearlyDeduction { get; set; }
        public decimal EmployeeYearlySalary { get; set; }
    }
}
