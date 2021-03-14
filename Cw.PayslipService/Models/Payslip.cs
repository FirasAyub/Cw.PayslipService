using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Models
{
    public class Payslip
    {
        public Employee EmployeeDetails { get; set; }
        
        public decimal MonthlyTax { 
            get
            {
                return CalculateEmployeeMonthlyTax();
            }             
        }

        public decimal NetMonthlySalary
        {
            get
            {
                return CalculateNetMothlySalary();
            }
        }

        private decimal CalculateEmployeeMonthlyTax()
        {
            return Math.Round(((EmployeeDetails.AnnualSalary > 150000) ? EmployeeDetails.AnnualSalary * (decimal)0.4 : EmployeeDetails.AnnualSalary * (decimal)0.3)/12, 2);
        }

        private decimal CalculateNetMothlySalary()
        {
            var tax = CalculateEmployeeMonthlyTax();

            return Math.Round((EmployeeDetails.AnnualSalary / 12) - tax, 2);
        }
    }
}
