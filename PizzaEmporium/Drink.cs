using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Drink : Product
    {
        private List<AddOns> Adds = new List<AddOns>();
        public string Type = "Drink";
        Sizes Size = null;

        public delegate void ListItems(string s);
        public event ListItems updateAddonReciept; //updates with addons

        public Drink()
        {
            this.Id = Type;
        }

        public Drink(string id, Sizes size, double price)
        {
            this.Id = id;
            this.Size = size;
            this.Price = price;
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
                if (Adds.Contains(add))
                {

                }
                else
                {
                    Adds.Add(add);
                    //TotalOrder();
                    updateAddonReciept("  - " + add.getAddOn);
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
                updateAddonReciept(s.getSize + " " + Id + " $" + Math.Round(s.getDrinkPrice,2));
                TotalOrder();
            }
            catch
            {

            }

        }

        public double TotalOrder() //does not calculate cost on drink AddOn, cost of drink based on Size.
        {
            Price = Size.getDrinkPrice;
            return Price;
        }

    }
}
