using System;
using System.Collections.Generic;
using Api.Configs;
using Api.Models;
using Api.Services;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiTests.Services
{
    [TestClass]
    public class DependentDeductionServiceTests
    {
        [TestMethod]
        public void When_SalaryCalculationService_calculations_correct_shouldPass()
        {
            var deductionSettings = new DeductionSettings()
            {
                EmployeePaychecks = 26,
                EmployeeMaxDeductionSalary = 80000,
                EmployeeDeductionPercentage = 2,
                DependentDeduction = 600,
                DependentAgeOver = 50,
                DependentOverDeduction = 200
            };

            var employee = new Employee()
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Salary = 80000,
                Dependents = new List<Dependent>() 
                {
                    new()
                    {
                        Id = 1,
                        FirstName = "TestSpouseFirstName",
                        LastName = "TestSpouseLastName",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1948, 3, 3),
                        EmployeeId = 1
                    }
                }
            };

            var salaryResults = new SalaryResults()
            {
                DependentsDeductionPerPayCheck = 800,
                DependentsYearlyDeduction = 9600,
                EmployeeDeductionPerPayCheck = 1000,
                EmployeeYearlyDeduction = 12000,
                TotalDeductionPerPayCheck = 1800,
                TotalYearlyDeduction = 21600
            };

            var employeeDeductionService = A.Fake<IEmployeeDeductions>();
            var dependentDeductionService = A.Fake<IDependentDeductions>();
            var salaryCalculatorService = A.Fake<ISalaryCalculatorService>();

            A.CallTo(() => employeeDeductionService.GetEmployeeSalaryDeductionsPerMonth(A<Employee>._, A<DeductionSettings>._)).Returns(1000);
            A.CallTo(() => dependentDeductionService.GetDependentDeductionPerPayCheck(A<List<Dependent>>._, A<DeductionSettings>._)).Returns(800);
            A.CallTo(() => salaryCalculatorService.CalculateEmployeeSalary(A<Employee>._, A<DeductionSettings>._)).Returns(salaryResults);


            var objectUnderTest = new SalaryCalculatorService(employeeDeductionService, dependentDeductionService);

            var calculatedResults = objectUnderTest.CalculateEmployeeSalary(employee, deductionSettings);

            Assert.IsTrue(salaryResults.DependentsDeductionPerPayCheck == calculatedResults.DependentsDeductionPerPayCheck);
            Assert.IsTrue(salaryResults.DependentsYearlyDeduction == calculatedResults.DependentsYearlyDeduction);
            Assert.IsTrue(salaryResults.EmployeeDeductionPerPayCheck == calculatedResults.EmployeeDeductionPerPayCheck);
            Assert.IsTrue(salaryResults.EmployeeYearlyDeduction == calculatedResults.EmployeeYearlyDeduction);
            Assert.IsTrue(salaryResults.TotalDeductionPerPayCheck == calculatedResults.TotalDeductionPerPayCheck);
            Assert.IsTrue(salaryResults.TotalYearlyDeduction == calculatedResults.TotalYearlyDeduction);
        }

        [TestMethod]
        public void When_SalaryCalculationService_calculations_incorrect_shouldFail()
        {
            var deductionSettings = new DeductionSettings()
            {
                EmployeePaychecks = 26,
                EmployeeMaxDeductionSalary = 80000,
                EmployeeDeductionPercentage = 2,
                DependentDeduction = 600,
                DependentAgeOver = 50,
                DependentOverDeduction = 200
            };

            var employee = new Employee()
            {
                Id = 1,
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Salary = 80000,
                Dependents = new List<Dependent>()
                {
                    new()
                    {
                        Id = 1,
                        FirstName = "TestSpouseFirstName",
                        LastName = "TestSpouseLastName",
                        Relationship = Relationship.Spouse,
                        DateOfBirth = new DateTime(1948, 3, 3),
                        EmployeeId = 1
                    }
                }
            };

            var salaryResults = new SalaryResults()
            {
                DependentsDeductionPerPayCheck = 800,
                DependentsYearlyDeduction = 9600,
                EmployeeDeductionPerPayCheck = 1000,
                EmployeeYearlyDeduction = 12000,
                TotalDeductionPerPayCheck = 1800,
                TotalYearlyDeduction = 21600
            };

            var employeeDeductionService = A.Fake<IEmployeeDeductions>();
            var dependentDeductionService = A.Fake<IDependentDeductions>();
            var salaryCalculatorService = A.Fake<ISalaryCalculatorService>();

            A.CallTo(() => employeeDeductionService.GetEmployeeSalaryDeductionsPerMonth(A<Employee>._, A<DeductionSettings>._)).Returns(1200);
            A.CallTo(() => dependentDeductionService.GetDependentDeductionPerPayCheck(A<List<Dependent>>._, A<DeductionSettings>._)).Returns(800);
            A.CallTo(() => salaryCalculatorService.CalculateEmployeeSalary(A<Employee>._, A<DeductionSettings>._)).Returns(salaryResults);


            var objectUnderTest = new SalaryCalculatorService(employeeDeductionService, dependentDeductionService);

            var calculatedResults = objectUnderTest.CalculateEmployeeSalary(employee, deductionSettings);

            Assert.IsFalse(salaryResults.EmployeeDeductionPerPayCheck == calculatedResults.EmployeeDeductionPerPayCheck);
        }
    }
}
