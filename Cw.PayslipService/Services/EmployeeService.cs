using Cw.PayslipService.Interfaces;
using Cw.PayslipService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Services
{
    public class EmployeeService : IEmployeeService
    {
        List<Employee> employees = new List<Employee>();
        public bool UpsertEmployee(Employee employee)
        {
            try
            {
                var emp = employees.FirstOrDefault(x => x.EmployeeNumber.Equals(employee.EmployeeNumber, StringComparison.InvariantCultureIgnoreCase));

                if (emp == null)
                {
                    if (string.IsNullOrWhiteSpace(employee.EmployeeNumber)
                        || string.IsNullOrWhiteSpace(employee.FirstName)
                        || string.IsNullOrWhiteSpace(employee.LastName)
                        || employee.AnnualSalary <= 0
                        )
                    {
                        //Log error message
                        throw new Exception();
                    }
                    employees.Add(employee);
                }
                else
                {
                    emp.EmployeeNumber = employee.EmployeeNumber;
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.AnnualSalary = employee.AnnualSalary;
                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Payslip> GetPayslips()
        {
            try
            {
                var payslips = new List<Payslip>();

                foreach (var employee in employees)
                {
                    var payslip = new Payslip()
                    {
                        EmployeeDetails = employee
                    };

                    payslips.Add(payslip);
                }

                return payslips;
            }
            catch (Exception)
            {
                //log exception details
                return null;
            }
        }
    }
}
