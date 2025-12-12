
using System;
using System.IO;
using System.Linq;
using LinqAdvancedLab.Data;

namespace LinqAdvancedLab.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            // Query 1
            var query1 = context.Products
                                .Where(p => p.UnitPrice > 50)
                                .OrderBy(p => p.ProductName);
            File.WriteAllText("docs/query1.sql", query1.ToQueryString());

            // Query 2
            var query2 = context.Orders
                                .Where(o => o.OrderDate.Year == 2023);
            File.AppendAllText("docs/query1.sql", "\n\n" + query2.ToQueryString());

            // Query 3
            var query3 = context.Customers
                                .Where(c => c.City == "Madrid");
            File.AppendAllText("docs/query1.sql", "\n\n" + query3.ToQueryString());

            // Query 4
            var query4 = context.Orders
                                .Where(o => o.TotalAmount > 1000);
            File.AppendAllText("docs/query1.sql", "\n\n" + query4.ToQueryString());

            Console.WriteLine("Queries ejecutadas y SQL guardado en docs/query1.sql");
        }
    }
}
