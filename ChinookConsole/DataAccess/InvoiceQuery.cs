using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ChinookConsole.DataAccess.Models;

namespace ChinookConsole.DataAccess
{
    class InvoiceQuery
    {
        readonly string _connectionString = ConfigurationManager.ConnectionStrings["Chinook"].ConnectionString;

        public List<SalesAgent> InvoiceWithSalesAgentName()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select Employee.FirstName + ' ' + Employee.LastName Name, Invoice.InvoiceId
                                    from Employee
                                    join Customer on Customer.SupportRepId = Employee.EmployeeId
                                    join Invoice on Invoice.CustomerId = Customer.CustomerId";

                connection.Open();
                var reader = cmd.ExecuteReader();

                var employees = new List<SalesAgent>();

                while (reader.Read())
                {
                    var employee = new SalesAgent
                    {
                        Name = reader["Name"].ToString(),
                        InvoiceId = int.Parse(reader["InvoiceId"].ToString())
                    };

                    employees.Add(employee);
                }

                return employees;
                
            }
        }

        public List<InvoiceTotal> InvoiceTotalWithCustomerNameCountryAndSalesAgent()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"select Customer.FirstName + ' ' + Customer.LastName CustomerFullName, 
                                           Customer.Country,
                                           Invoice.Total,
                                           Employee.FirstName + ' ' + Employee.LastName as [Sales Agent]
                                    from Customer 
                                        join Invoice on Invoice.CustomerId = Customer.CustomerId
                                        join Employee on Employee.EmployeeId = Customer.SupportRepId";

                connection.Open();
                var reader = cmd.ExecuteReader();

                var invoiceTotals = new List<InvoiceTotal>();

                while (reader.Read())
                {
                    var invoice = new InvoiceTotal
                    {
                        CustomerFullName = reader["CustomerFullName"].ToString(),
                        Country = reader["Country"].ToString(),
                        Total = double.Parse(reader["Total"].ToString()),
                        SalesAgentName = reader["Sales Agent"].ToString()
                    };

                    invoiceTotals.Add(invoice);
                }
                return invoiceTotals;
            }
        }

       
    }
}
