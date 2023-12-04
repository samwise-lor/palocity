using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class GetEmployeeSalaryDto
    {
        public decimal TotalDeductionPerPayCheck { get; set; }

        public decimal DependentsDeductionPerPayCheck { get; set; }

        public decimal EmployeeDeductionPerPayCheck { get; set; }
    }
}
