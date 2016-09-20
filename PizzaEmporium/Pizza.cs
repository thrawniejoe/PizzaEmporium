using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Pizza : Product, iProducts
    {
        private List<AddOns> Adds = new List<AddOns>();
        public string Type = "Pizza";
        Sizes Size = null;

        public delegate void ListItems(string s);
        public event ListItems updateAddonReciept; //updates with addons

        public Pizza()
        {
            this.Id = "Pizza";
        }

        public Pizza(Sizes size)
        {
            this.Id = Type;
            this.Size = size;
            this.Price = size.getPrice;
        }
        public Sizes setSize 
        {
            get { return Size; }
            set { Size = value; }
        }

        public void setAddon(AddOns add)
        {
            try
            {
                if(Adds.Contains(add))
                {

                }
                else
                {
                    Adds.Add(add);
                    TotalOrder();
                    updateAddonReciept("  - " + add.getAddOn + " $" + Convert.ToString(Math.Round(add.getPrice,2)));
                }
            }
            catch
            {

            }


        }

        public void pickSize(Sizes s)
        {
            try
            {
                Size = s;
                //Price = Price + s.getPrice;
                updateAddonReciept(s.getSize + " " + Id + " $" + Math.Round(s.getPrice, 2));

            }
            catch
            {

            }
 }

        public double TotalOrder()
        {
            double total = 0;
            try
            {
                foreach (AddOns p in Adds)
                {
                    total = total + p.getPrice;
                }
            
                Price = total + Size.getPrice;
            }
            catch
            {

            }

            return Price;
        }

        //public void SaveOrder()
        //{
        //    OrdersDA.AddProductToDB(Id, Price);
        //}
    }
}
