using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Sizes
    {
        private string Size;
        private double Price;
        private double DrinkPrice;

        public Sizes() { }

        public Sizes(string sizeChoice, double price, double dPrice)
        {
            this.Size = sizeChoice;
            this.Price = price;
            this.DrinkPrice = dPrice;
        }

        public double getDrinkPrice
        {
            get { return DrinkPrice; }
        }
        public string getSize
        {
            get { return Size; }
        }

        public double getPrice
        {
            get { return Price; }
        }
    }
}
