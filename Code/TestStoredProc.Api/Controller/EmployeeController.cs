using System;
using TestStoredProc.BusinessServices.Interfaces;
using TestStoredProc.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TestStoredProc.Entities;
using System;
using System.Collections.Generic;

namespace TestStoredProc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }

        [HttpPost("GetEmployee")]
        public IActionResult GetEmployee(EmployeeInput employee)
        {
            return new ObjectResult(employeeService.GetEmployee(employee));
        }
    }
}