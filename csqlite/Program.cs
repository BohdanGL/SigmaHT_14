using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Linq;


namespace csqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            Db db = new Db("Data Source=data.db");

            List<Product> products = db.GetProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine(db.GetProductLinq("Milk"));
            Console.WriteLine();
            Console.WriteLine(db.GetProduct("Bread"));
        }
    }
}
