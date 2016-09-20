using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Product
    {
        private string Description;
        public double Price { get; set; }
        public string Id;

        public Product() { }

        public Product(string id, double price, string description)
        {
            this.Id = id;
            this.Price = price;
            this.Description = description;
        }

        public string getId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
