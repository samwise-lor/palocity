using Api.Configs;
using Api.Models;

namespace Api.Services
{
    public class DependentDedutionsService : IDependentDeductions
    {        
        public decimal GetDependentDeductionPerPayCheck(List<Dependent> dependents, DeductionSettings deductionSettings)
        {
            var ageOver = deductionSettings.DependentAgeOver;
            var dependentDeduction = deductionSettings.DependentDeduction;
            var dependentOverDeduction = deductionSettings.DependentOverDeduction;

            if (dependents.Count == 0) return 0;
            var dependentCount = dependents.Count;
            var dependetsOverFifty = (from z in dependents
                      select new
                      {
                          Age = DateTime.Now.Year - z.DateOfBirth.Year,
                          BirthDate = z.DateOfBirth
                      }).ToList()
                      .Where(x => x.Age > ageOver).Count();

            return dependetsOverFifty > 0
                ? ((dependentCount * dependentDeduction) + dependentOverDeduction)
                : (dependentCount * dependentDeduction);
        }
    }
}
