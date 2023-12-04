namespace Api.Models;

public class Employee : Person
{
    public decimal Salary { get; set; }
    public decimal BaseDeduction { get; } = 1000;
    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
}
