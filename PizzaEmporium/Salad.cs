using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Salad : Product
    {
        public string Type = "Salad";
        Salads MySalad = null;

        public delegate void ListItems(string s);
        public event ListItems updateAddonReciept; //updates with addons

        public Salad()
        {
            this.Id = Type;
        }

        public Salad(Salads sal)
        {
            this.Id = Type;
            this.MySalad = sal;
        }
        public Salads setSalad
        {
            get { return setSalad; }
            set { setSalad = value; }
        }

        public void pickSalad(Salads s)
        {
            MySalad = s;
            //Price = Price + s.getPrice;
            updateAddonReciept(s.getSalad + " " + Id + " $" + Math.Round(s.getPrice, 2));
            TotalOrder();
        }

        public double TotalOrder()
        {
            Price = MySalad.getPrice;
            return Price;
        }

        //public void SaveOrder()
        //{
        //    OrdersDA.AddProductToDB(Id, Price);
        //}
    }
}
