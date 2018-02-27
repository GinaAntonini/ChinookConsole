using System;
using ChinookConsole.DataAccess;

namespace ChinookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var invoiceQuery = new InvoiceQuery(); //instance of the InvoiceQuery class

            var invoices = invoiceQuery.InvoiceWithSalesAgentName(); //declaring invoice variable, to use the method to get the Sales agent name and invoice 

            Console.WriteLine("Sales agents and Invoice Ids");

            foreach (var invoice in invoices)
            {
                Console.WriteLine($"SalesAgent: {invoice.Name}, Invoice Id: {invoice.InvoiceId}");
            }

            invoiceQuery = new InvoiceQuery();

            var invoiceTotals = invoiceQuery.InvoiceTotalWithCustomerNameCountryAndSalesAgent();

            Console.WriteLine("Invoice Totals with Customer Name, Billing Country, and Sales Agent");

            foreach (var invoiceTotal in invoiceTotals)
            {
                Console.WriteLine($"Customer Full Name: {invoiceTotal.CustomerFullName}, Invoice Total: {invoiceTotal.Total}, Billing Country: {invoiceTotal.Country}, Sales Agent: {invoiceTotal.SalesAgentName}");
            }


            Console.ReadLine();
        }
    }
}
