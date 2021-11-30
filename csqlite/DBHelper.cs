using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csqlite
{
    static class DBHelper //extensions
    {
        public static List<Product> GetProducts(this Db db)
        {
            return db.GetList<Product>("select * from PRODUCT", Product.Create);
        }

        //sql
        public static Product GetProduct(this Db db, string name)
        {
            return db.GetList<Product>($"select * from Product where Name like '{name}%' limit 1", Product.Create).FirstOrDefault();
        }

        //linq
        public static Product GetProductLinq(this Db db, string name)
        {
            return db.GetProducts().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
