using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEmporium
{
    interface iProducts
    {
        double TotalOrder();
        void pickSize(Sizes s);
        void setAddon(AddOns add);
    }
}
