using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    interface iOrder
    {
        double CalculateTax();
        double TotalOrder();
        void AddItem(Product item);
        void SaveOrder();
        void DeleteItem();
        //Product setAddon();
    } 
}
