using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EmployeeContext(serviceProvider.GetRequiredService<DbContextOptions<EmployeeContext>>());
            if (context.Employees.Any())
            {
                return;   // Database has been seeded
            }

            context.Employees.AddRange(
                new Employee
                {
                    Id = 1,
                    FirstName = "LeBron",
                    LastName = "James",
                    Salary = 20000m,
                    DateOfBirth = new DateTime(1984, 12, 30),
                    Dependents = new List<Dependent>() 
                    {
                        new()
                        {
                            Id = 1,
                            FirstName = "Spouse",
                            LastName = "James",
                            Relationship = Relationship.Spouse,
                            DateOfBirth = new DateTime(1948, 3, 3),
                            EmployeeId = 1
                        }
                    }    
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Ja",
                    LastName = "Morant",
                    Salary = 92365.22m,
                    DateOfBirth = new DateTime(1999, 8, 10),
                    Dependents = new List<Dependent>()
                    {
                        new()
                        {
                            Id = 2,
                            FirstName = "Spouse",
                            LastName = "Morant",
                            Relationship = Relationship.Spouse,
                            DateOfBirth = new DateTime(1998, 3, 3),
                            EmployeeId = 2,
                        },
                        new()
                        {
                            Id = 3,
                            FirstName = "Child1",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2020, 6, 23),
                            EmployeeId = 2,
                        },
                        new()
                        {
                            Id = 4,
                            FirstName = "Child2",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2021, 5, 18),
                            EmployeeId = 2,
                        }
                    }
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    Salary = 143211.12m,
                    DateOfBirth = new DateTime(1963, 2, 17)
                });

            context.SaveChanges();
        }
    }
}
