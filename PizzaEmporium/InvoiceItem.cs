using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class InvoiceItem
    {
        private Order Item;
        private int Id;
        private double Price;

        public InvoiceItem()
        {

        }

        public InvoiceItem(int id, Order items)
        {
            this.Id = id;
            this.Item = items;
        }

        public void getItems(Order p)
        {
            Price = p.TotalOrder();
        }

        public string toString()
        {
            return "Order# " + Item.Id + " with a Total of $" + Price;
        }
    }
}
