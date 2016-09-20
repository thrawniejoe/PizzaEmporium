using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Specials : Product
    {
        private List<AddOns> Adds = new List<AddOns>();
        public string Type = "Special Pizza";
        Sizes Size = null;

        public delegate void ListItems(string s);
        public event ListItems updateAddonReciept; //updates with addons

        public Specials()
        {
            //this.Id = Type;
        }

        public Specials(string id, Sizes size, double price)
        {
            this.Id = id;
            this.Size = size;
            this.Price = price;
        }

        public string setId
        {
            get { return Id; }
            set { Id = value; }
        }

        public Sizes setSize
        {
            get { return Size; }
            set { Size = value; }
        }

        public void setAddon(AddOns add)
        {
            if (Adds.Contains(add))
            {

            }
            else
            {
                Adds.Add(add);
                //TotalOrder();
                //updateAddonReciept("  - " + add.getAddOn + " $" + Convert.ToString(Math.Round(add.getPrice,2)));
            }

        }

        public void pickSize(Sizes s)
        {
            Size = s;
            //Price = Price + s.getPrice;
            TotalOrder();
            updateAddonReciept(Id + " $" + Math.Round(Price, 2));
        }



        public double TotalOrder() //gives a 10% discount on expired special items
        {
            foreach(AddOns a in Adds)
            {
                Price = Price + a.getPrice;
                //updateAddonReciept("  - " + a.getAddOn + " $" + Convert.ToString(Math.Round(a.getPrice, 2)));
            }
            
            //Price = Size.getPrice;
            double discount = Price * .1;
            Price = Price - discount;
            return Price;
        }

        //public void SaveOrder()
        //{
        //    OrdersDA.AddProductToDB(Id, Price);
        //}

        
    }
}
