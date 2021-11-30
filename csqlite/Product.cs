using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace csqlite
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public int ExpirationDate { get; set; }
        public string ProductionDate { get; set; }

        public Product(string name, double price, double weight, int expirationDate, string productionDate)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
            ProductionDate = productionDate;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            Product product = (Product)obj;
            return (this.Name == product.Name);
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPrice: {Price}\nWeight: {Weight}\n" +
                $"Expiration date: {ExpirationDate}\nProduction date: {ProductionDate}\n";
        }

        public static Product Create(IDataRecord data)
        {
            return new Product(data["NAME"].ToString(), Convert.ToDouble(data["PRICE"])
                , Convert.ToDouble(data["WEIGHT"]), Convert.ToInt32(data["EXPIRATIONDATE"])
                ,data["PRODUCTIONDATE"].ToString());
        }

        public virtual void ChangePrice(double percentage)
        {
            Price += percentage * Price / 100;
        }
    }
}
