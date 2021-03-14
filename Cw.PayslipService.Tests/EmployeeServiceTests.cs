using Cw.PayslipService.Models;
using Cw.PayslipService.Services;
using NUnit.Framework;

namespace Cw.PayslipService.Tests
{
    public class Tests
    {
        private EmployeeService employeeService;

        [SetUp]
        public void Setup()
        {
            employeeService = new EmployeeService();
        }

        [Test]
        public void AddEmployee_Valid_Request()
        {
            // Arrange
            var emp = new Employee()
            {
                EmployeeNumber = "emp-1",
                FirstName = "Test First 1",
                LastName = "Test Last 1",
                AnnualSalary = 120000
            };

            // Act
            var results = employeeService.UpsertEmployee(emp);

            // Assert
            Assert.IsTrue(results);

        }


        [Test]
        public void AddEmployee_InValid_Request()
        {
            // Arrange
            // missing Annual Salary
            var emp = new Employee()
            {
                EmployeeNumber = "emp-1",
                FirstName = "Test First 1",
                LastName = "Test Last 1"
            };

            // Act
            var results = employeeService.UpsertEmployee(emp);

            // Assert
            Assert.IsFalse(results);

        }

        [Test]
        public void GetPayslips_Request()
        {
            // Arrange
            var emp = new Employee()
            {
                EmployeeNumber = "emp-1",
                FirstName = "Test First 1",
                LastName = "Test Last 1",
                AnnualSalary = 120000
            };
            var res = employeeService.UpsertEmployee(emp);


            // Act
            var results = employeeService.GetPayslips();

            // Assert
            Assert.IsTrue(res);
            Assert.IsNotNull(results);
        }

    }
}