using Api.Models;

namespace Api.Services
{
    public interface IDependentDeductions
    {
        decimal GetDependentDeductionPerPayCheck(List<Dependent> dependents);
    }
}
