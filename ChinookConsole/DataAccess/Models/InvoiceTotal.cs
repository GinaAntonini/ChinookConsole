using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookConsole.DataAccess.Models
{
    class InvoiceTotal
    {
        public string CustomerFullName { get; set; }
        public string Country { get; set; }
        public double Total { get; set; }
        public string SalesAgentName { get; set; }
    }
}
