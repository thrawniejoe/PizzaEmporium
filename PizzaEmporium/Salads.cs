using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Salads
    {
        private string Salad;
        private double Price;

        public Salads() { }

        public Salads(string saladChoice, double price)
        {
            this.Salad = saladChoice;
            this.Price = price;
        }

        public string getSalad
        {
            get { return Salad; }
        }

        public double getPrice
        {
            get { return Price; }
        }

        //public void SaveOrder()
        //{
        //    OrdersDA.AddProductToDB(Id, Price);
        //}
    }
}
