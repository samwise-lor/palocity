using Api.Models;

namespace Api.Services
{
    public class DependentDedutionsService : IDependentDeductions
    {        
        public decimal GetDependentDeductionPerPayCheck(List<Dependent> dependents)
        {
            var ageOverFifty = Constants.dependentAgeOverFifty;
            var dependentDeduction = Constants.dependentDeduction;
            var dependentOverFiftyDeduction = Constants.dependentOverFiftyDeduction;

            if (dependents.Count == 0) return 0;
            var dependentCount = dependents.Count;
            var dependetsOverFifty = (from z in dependents
                      select new
                      {
                          Age = DateTime.Now.Year - z.DateOfBirth.Year,
                          BirthDate = z.DateOfBirth
                      }).ToList()
                      .Where(x => x.Age > ageOverFifty).Count();

            return dependetsOverFifty > 0
                ? ((dependentCount * dependentDeduction) + dependentOverFiftyDeduction)
                : (dependentCount * dependentDeduction);
        }
    }
}
