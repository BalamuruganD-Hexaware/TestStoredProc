using TestStoredProc.Entities;
using System;
using System.Collections.Generic;

namespace TestStoredProc.BusinessServices.Interfaces 
{
    public interface IEmployeeService
    {
        List<EmployeeOutput> GetEmployee(EmployeeInput employee);
    }
}