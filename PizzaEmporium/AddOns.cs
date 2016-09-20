using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class AddOns
    {
        private string AddOn;
        private double Price;

        public AddOns() { }

        public AddOns(string addOnChoice, double price)
        {
            this.AddOn = addOnChoice;
            this.Price = price;
        }

        public string getAddOn
        {
            get { return AddOn; }
        }

        public double getPrice
        {
            get { return Price; }
        }
    }
}
