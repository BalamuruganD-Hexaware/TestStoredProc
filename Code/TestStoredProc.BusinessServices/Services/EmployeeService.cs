using TestStoredProc.BusinessServices.Interfaces;
using TestStoredProc.Entities;
using TestStoredProc.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace TestStoredProc.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        // private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        public List<EmployeeOutput> GetEmployee(EmployeeInput employee)
        {
            return employeeRepo.GetEmployee(employee);
        }
    }
}