using TestStoredProc.Entities;
using System;
using System.Collections.Generic;

namespace TestStoredProc.Data.Interfaces 
{
    public interface IEmployeeRepo
    {
        List<EmployeeOutput> GetEmployee(EmployeeInput employee);
    }
}