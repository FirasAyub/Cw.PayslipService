using Cw.PayslipService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Interfaces
{
    public interface IEmployeeService
    {
        bool UpsertEmployee(Employee request);

        List<Payslip> GetPayslips();
    }
}
