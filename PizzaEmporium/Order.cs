using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    class Order : iOrder
    {
        public delegate void ListItems(string s);
        public event ListItems updateReciept;

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ItemOrdered { get; set; }
        public double Price { get; set; }
        public string Branch = "Joe Velasquez";

        private List<Product> orderItems = new List<Product>();

        public Order()
        {
            Id = OrdersDA.getLastID() + 1;
            Date = DateTime.Now;
            Price = 0;
            Branch = "Joe Velasquez";
        }

        public Order(int id, Product item, string branchName, DateTime date, double price)
        {
            this.Id = id;
            this.Date = date;
            this.Branch = branchName;
            this.Price = price;
            this.orderItems.Add(item);
        }

        public void AddItem(Product item)
        {
            OrdersDA.AddProductToDB(item);
            orderItems.Add(item);
        }

        //Gets all items in an order and posts it to the display
        private void getItemsOnOrder()
        {
                //lstReceipt.Items.Clear();
                foreach (Product i in orderItems)
                {
                    updateReciept(Convert.ToString(i.Id) + " $" + Convert.ToString(Math.Round(i.Price,2)));               
                }
        }


        public double CalculateTax()
        {
            double tax;
            tax = Price * .10;

            return Math.Round(tax,2); 
        }

        public double TotalOrder()
        {
            double total = 0;

            foreach(Product p in orderItems)
            {
                total = total + p.Price;
                
            }
            Price = total;
            updateReciept("");
            updateReciept("Order Tax: $" + CalculateTax());
            updateReciept("----------------------");
            Price = Price + CalculateTax();
            updateReciept("Order Total: $" + Math.Round(Price,2));
            updateReciept("");
            updateReciept(ToString());
            SaveOrder();
            return Price;
        }

        public void SaveOrder()
        {
            updateReciept("Order Information Saved");
        }

        public void DeleteItem()
        {
            updateReciept("Item Removed.");
        }

        public override string ToString()
        {
            return Date + " " + Id + " " + Branch + " $" + Math.Round(Price,2);
        }

    }
}
