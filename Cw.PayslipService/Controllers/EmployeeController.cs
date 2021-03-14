using Cw.PayslipService.Interfaces;
using Cw.PayslipService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw.PayslipService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("UpsertEmployee")]
        public IActionResult UpsertEmployee(Employee employee)
        {
            try
            {
                var response = _employeeService.UpsertEmployee(employee);

                if (!response)
                    return BadRequest(new { message = "employee could not be saved" });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem($"unexpected error occurred - {ex.Message}");
            }
        }

        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [HttpGet("GetPayslips")]
        public IActionResult GetPayslips()
        {
            try
            {
                var response = _employeeService.GetPayslips();

                if (response == null)
                    return BadRequest(new { message = "payslips could not be obtained." });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem($"unexpected error occurred - {ex.Message}");
            }
        }
    }
}
