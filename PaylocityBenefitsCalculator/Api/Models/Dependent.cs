namespace Api.Models;

public class Dependent : Person
{
    public Relationship Relationship { get; set; }
    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }
}
