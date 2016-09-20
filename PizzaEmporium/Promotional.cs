using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Promotional : Product
    {
        public string Type;
        Sizes Size = null;

        public delegate void ListItems(string s);
        public event ListItems updateAddonReciept; //update list

        public Promotional()
        {
        }

        public Promotional(string id, double price) : base()
        {
            this.Id = id;

            this.Price = price;
        }

        public Sizes setSize
        {
            get { return Size; }
            set { Size = value; }
        }

        public void pickSize(Promotional s)
        {
            
            Price = s.Price;   
            //Price = Price + s.getPrice;
            updateAddonReciept(s.getId + " " + Id + " $" + Math.Round(TotalOrder(), 2));
            TotalOrder();
        }

        public void getPromo(int i)
        {
            
        }
        public double TotalOrder() 
        {
            
            return Price;
        }
    }
}
