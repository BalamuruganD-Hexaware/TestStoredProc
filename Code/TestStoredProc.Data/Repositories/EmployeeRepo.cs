using Dapper;
using System.Data.SqlClient;
using TestStoredProc.Data.Interfaces;
using TestStoredProc.Entities;
using System;
using System.Collections.Generic;

namespace TestStoredProc.Data.Repositories 
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public List<EmployeeOutput> GetEmployee(EmployeeInput employee)
        {
            string connectionString = "Server=tcp:rapidx-template-mssql.database.windows.net,1433;Initial Catalog=rapidx;Persist Security Info=False;User ID=rapidx_mssql;Password=Password123";
            SqlConnection connection = new SqlConnection(connectionString);
            var result = (List<EmployeeOutput>) connection.Query<List<EmployeeOutput>>("getEmployee", employee, commandType: System.Data.CommandType.StoredProcedure);
            Console.WriteLine(result);
            connection.Close();
            return result;
        }
    }
}