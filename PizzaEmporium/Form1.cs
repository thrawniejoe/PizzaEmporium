//---------------------------
// Author: Joe Velasquez
// Date: 09/17/2015
//
// Description: I wanted to note that I just realized(09/17/2015 at 10:30am) I was suppose to post the information for each item to the table. I had it setup to send 
//              the final order information ie: Date, Order ID, BranchName and Total of Order. I build it from the ground up like that and now that i see that its per item
//              im struggeling to rebuild it the correct way. But either way was a very fun project.
//
// Database Directions: To Connect to the table change the connectionString AttachedDBFilename in OrdersDA line 21 to current location of the program
//--------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaEmporium
{
    public partial class frmMain : Form
    {
        //----------
        //Menu Items
        //----------
        public int OrderNumber;
        private List<Sizes> itemSizes = null;
        private List<String> menuList = null;
        private List<AddOns> addOnList = null;
        private List<Salads> saladList = null;
        private List<AddOns> drinkSelectionList = null;
        private RadioButton[] sizeRb = new RadioButton[3];
        private RadioButton[] saladRb = new RadioButton[6];
        private List<Product> specialsList = null;
        private List<Promotional> promoList = null;

        CheckBox[] addOnRb = null;
        //iOrder iord = new Order();

        //iOrder newOrder = new Order();

        Order newOrder = new Order();
        Pizza newPizza = null;
        private int currentMenu = 0;

        //----------
        //Order Data
        //----------

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            itemSizes = OrdersDA.GetAllSizes();
            menuList = OrdersDA.GetMenuItems();
            drinkSelectionList = OrdersDA.GetDrinkAddOns();
            promoList = OrdersDA.getPromotional();
            addOnList = OrdersDA.GetAddOns();
            addOnRb = new CheckBox[addOnList.Count()];
            saladList = OrdersDA.GetSalads();
            specialsList = OrdersDA.getSpecials();
            DateTime adate = DateTime.Parse("11/24/2015");
            OrderNumber = OrdersDA.getLastID();
        }


        //********************
        //Adds item to order
        //********************
        private void addToOrder()
        {
            switch (currentMenu)
            {
                case 0:
                    pizzaSelectionRT();
                    break;
                case 1:
                    drinkSelectionRT();
                    break;
                case 2:
                    //salads
                    saladSelectionRT();
                    break;
                case 3:
                    specialsSelectionRT();
                    break;
                case 4:
                    coolStuffSelectionRT();
                    //cool stuff
                    break;
                default:
                    break;
            }
        }

        private void coolStuffSelectionRT()
        {
            Promotional newPromo = new Promotional();
            newPromo.updateAddonReciept += new Promotional.ListItems(recieptInfo);

            //check to see which size is checked
            foreach (RadioButton rb in sizeRb)
            {
                try
                {
                    if (rb.Checked) //looks to see what size was picked
                    {
                        newPromo.pickSize(promoList[rb.TabIndex]);
                        //adds the salad to the order
                        newOrder.AddItem(newPromo);
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                }

            }
        }
        private void saladSelectionRT()
        {
            Salad newSalad = new Salad();
            newSalad.updateAddonReciept += new Salad.ListItems(recieptInfo);

            //check to see which size is checked
            foreach (RadioButton rb in saladRb)
            {
                try
                {
                    if (rb.Checked) //looks to see what size was picked
                    {
                        newSalad.pickSalad(saladList[rb.TabIndex]);
                        //adds the salad to the order
                        newOrder.AddItem(newSalad);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(Convert.ToString(e));
                }

            }
        }

        private void drinkSelectionRT()
        {
            Drink newDrink = new Drink();
            newDrink.updateAddonReciept += new Drink.ListItems(recieptInfo);
            bool isChecked = false;

            try
            {
                //check to see which size is checked
                foreach (RadioButton rb in sizeRb)
                {
                    if (rb.Checked) //looks to see what size was picked
                    {
                        newDrink.pickSize(itemSizes[rb.TabIndex]);
                        isChecked = true;
                        newOrder.AddItem(newDrink);
                    }
                }
                //check to see which addons are selected then add them
                if (isChecked == true) //looks to see what size was picked
                {
                    for (int index = 0; index < addOnRb.Length; index++)
                    {
                        if (addOnRb[index].Checked)
                        {
                            newDrink.setAddon(drinkSelectionList[index]);
                        }
                    }
                    //adds the pizza to the order
                    
                    // newPizza.SaveOrder();
                }
                else
                {
                    MessageBox.Show("Please Choose a size");
                }
            }
            catch
            {

            }
        }
        
        //Add from Specials
        private void specialsSelectionRT()
        {
            Specials newSpecial = new Specials();
            newSpecial.updateAddonReciept += new Specials.ListItems(recieptInfo);
            bool isChecked = false;
            try
            {
                //check to see which size is checked
                foreach (RadioButton rb in sizeRb)
                {
                    if (rb.Checked) //looks to see what size was picked
                    {
                        newSpecial.pickSize(itemSizes[rb.TabIndex]);
                        newSpecial.Price = specialsList[rb.TabIndex].Price;
                             isChecked = true;
                    }
                }
                //adds the speical to the order
                newOrder.AddItem(newSpecial);
            }
            catch
            {

            }
        }

        //Adding from pizza's menu
        private void pizzaSelectionRT()
        {
            Pizza newPizza = new Pizza();
            newPizza.updateAddonReciept += new Pizza.ListItems(recieptInfo);
            bool isChecked = false;
            try
            {
                //check to see which size is checked
                foreach (RadioButton rb in sizeRb)
                {
                    if (rb.Checked) //looks to see what size was picked
                    {
                        newPizza.pickSize(itemSizes[rb.TabIndex]);
                        isChecked = true;
                    }
                }
                //check to see which addons are selected then add them
                if (isChecked == true) //looks to see what size was picked
                {
                    for (int index = 0; index < addOnRb.Length; index++)
                    {
                        if (addOnRb[index].Checked)
                        {
                            newPizza.setAddon(addOnList[index]);
                        }
                    }
                    //adds the pizza to the order
                    newOrder.AddItem(newPizza);
                   // newPizza.SaveOrder();
                }
                else
                {
                    MessageBox.Show("Please Choose a size");
                }
            }
            catch
            {

            }
        }


        void recieptInfo(string s)
        {
            //lstReceipt.Items.Clear();
            lstReceipt.Items.Add(s);
        }

        //********************
        // Creats a dynamic RadioButton array based on a list of Salads found in OrdersDA
        //********************
        private void displaySalads()
        {
            int startTop = 20;
            int startLeft = 35;

            int numCols = 1;
            int numRows = 6;

            int totalItems = saladList.Count;

            //MessageBox.Show(Convert.ToString(totalAppliances));
            RadioButton[] salad = new RadioButton[totalItems];  // create an array that holds radiobutton objects

            // now loop through the array of RadioButtons and add a new RadioButton and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                        if (i < totalItems)
                        {
                            salad[i] = new RadioButton();
                            salad[i].Text = Convert.ToString(saladList[i].getSalad) + " Salad";
                            salad[i].Size = new Size(150, 20);
                            salad[i].Location = new Point(startLeft + (120 * y), startTop + (35 * x));
                            salad[i].Tag = i + 1;
                            salad[i].Click += new EventHandler(mySizeHandler);
                            saladRb[i] = salad[i];
                            pnlOptions.Controls.Add(salad[i]);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }


        //********************
        // Creats a dynamic RadioButton array based on a list of Drink/Snack Sizes found in OrdersDA
        //********************
        private void displaySizes() 
        {
            int startTop = 20;
            int startLeft = 35;

            int numCols = 1;
            int numRows = 3;

            int totalItems = itemSizes.Count;

            //MessageBox.Show(Convert.ToString(totalAppliances));
            RadioButton[] size = new RadioButton[totalItems];  // create an array that holds radiobutton objects

            // now loop through the array of RadioButtons and add a new RadioButton and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                        if (i < totalItems)
                        {
                            
                            size[i] = new RadioButton();
                            if(currentMenu == 4)
                            {
                                size[i].Text = Convert.ToString(itemSizes[i].getSize)+ " " + promoList[i].getId;
                                size[i].Size = new Size(290, 20);
                            }
                            else
                            {
                                size[i].Text = Convert.ToString(itemSizes[i].getSize);
                                size[i].Size = new Size(100, 20);
                            }
                            
                            
                            size[i].Location = new Point(startLeft + (120 * y), startTop + (35 * x));
                            size[i].Tag = i + 1;
                            size[i].Click += new EventHandler(mySizeHandler);
                            sizeRb[i] = size[i];
                            pnlOptions.Controls.Add(size[i]);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        //********************
        //Adds selected size item to order
        //********************
        private void mySizeHandler(object sender, EventArgs e)
        {
        }

        //********************
        // Creats a dynamic CheckBox array based on a list of AddOn item for pizza found in OrdersDA
        //********************
        private void displayAddons()
        {
            int startTop = 20;
            int startLeft = 200;
            int totalAddons = 0;

            switch (currentMenu)
            {
                case 0:
                    totalAddons = addOnList.Count;

                    break;
                case 1:
                    totalAddons = drinkSelectionList.Count;

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }

//            int totalAddons = addOnList.Count;
            int numCols = 1;
            int numRows = totalAddons;

            CheckBox[] addon = new CheckBox[totalAddons];  // create an array that holds radiobutton objects
            
            // now loop through the array of RadioButtons and add a new RadioButton and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                        if (i < totalAddons)
                        {
                            addon[i] = new CheckBox();
                            addon[i].Text = Convert.ToString(gItemName(i));
                            addon[i].Size = new Size(90, 20);
                            addon[i].Location = new Point(startLeft + (120 * y), startTop + (35 * x));
                            addon[i].Tag = i;
                            addon[i].Click += new EventHandler(myAddonHandler);
                            addOnRb[i] = addon[i];
                            pnlOptions.Controls.Add(addon[i]);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }


        private string gItemName(int i)
        {
            string itemName = "";
            switch (currentMenu)
            {
                case 0:
                    itemName = addOnList[i].getAddOn;
                    break;
                case 1:
                    itemName = drinkSelectionList[i].getAddOn;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break; 
            }
            return itemName;
        }

        //Adds selected AddOn item to order
        private void myAddonHandler(object sender, EventArgs e)
        {

        }
        //****************************
        //
        // Creates Menu Selection List
        //
        //****************************
        private void displayMenu()
        {
            int startTop = 20;
            int startLeft = 35;

            int numCols = 5;
            int numRows = 1;

            int totalAppliances = menuList.Count;

            //MessageBox.Show(Convert.ToString(totalAppliances));
            Button[] Menu = new Button[totalAppliances];  // create an array that holds radiobutton objects

            //now loop through the array of RadioButtons and add a new RadioButton and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                        if (i < totalAppliances)
                        {
                            Menu[i] = new Button();
                            Menu[i].Text = Convert.ToString(menuList[i].ToString());
                            Menu[i].Size = new Size(80, 60);
                            Menu[i].Location = new Point(startLeft + (120 * y), startTop + (35 * x));
                            Menu[i].Tag = i;
                            Menu[i].Click += new EventHandler(menuSelect);
                            pnlMenuItems.Controls.Add(Menu[i]);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        //********************
        // Creats a dynamic RadioButton array based on a list of Drink/Snack Sizes found in OrdersDA
        //********************
        private void displaySpecials()
        {
            int startTop = 20;
            int startLeft = 35;

            int numCols = 1;
            int numRows = 3;

            int totalItems = 2;

            //MessageBox.Show(Convert.ToString(totalAppliances));
            RadioButton[] size = new RadioButton[totalItems];  // create an array that holds radiobutton objects

            // now loop through the array of RadioButtons and add a new RadioButton and where it goes on the form.
            try
            {
                int i = 0;
                for (int x = 0; x < numRows; x++)
                {

                    for (int y = 0; y < numCols; y++)
                    {
                        if (i < totalItems)
                        {

                            size[i] = new RadioButton();
                            size[i].Text = Convert.ToString(specialsList[i].Id);
                            size[i].Size = new Size(200, 20);
                            size[i].Location = new Point(startLeft + (120 * y), startTop + (35 * x));
                            size[i].Tag = i + 1;
                            //size[i].Click += new EventHandler(mySpecialsHandler);
                            sizeRb[i] = size[i];
                            pnlOptions.Controls.Add(size[i]);
                            i++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }

        //********************
        //Click action for the displayMenu() buttons, this is choose which options display in the addons's panel
        //********************
        private void menuSelect(object sender, EventArgs e)
        {
            Button selected = (Button)sender;

            int index = Convert.ToInt16(selected.Tag);
            switch (index)
            {
                case 0:
                    currentMenu = 0;
                    pnlOptions.Controls.Clear();//
                    displaySizes();
                    displayAddons();
                    break;
                case 1:
                    currentMenu = 1;
                    pnlOptions.Controls.Clear();//
                    displaySizes();
                    displayAddons();
                    break;
                case 2:
                    currentMenu = 2;
                    pnlOptions.Controls.Clear();//
                    displaySalads();
                    break;
                case 3:
                    currentMenu = 3;
                    pnlOptions.Controls.Clear();//
                    displaySpecials();
                    
                    break;
                case 4:
                    currentMenu = 4;
                    pnlOptions.Controls.Clear();//
                    
                    displaySizes();
                    
                    break;
                default:
                    currentMenu = 0;
                    pnlOptions.Controls.Clear();
                    break;
            }
        }

        //********************
        // Finish Order Button
        //********************
        private void btnFinishOrder_Click(object sender, EventArgs e)
        {
            newOrder.TotalOrder();

            OrderNumber++;
            //newOrder = new Order(OrderNumber, "Joe Velasquez", DateTime.Now, 0);
            //newOrder.updateReciept += new Order.ListItems(recieptInfo);
            //MessageBox.Show(Convert.ToString(OrderNumber));
            hideScreen();
        }

        //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addToOrder();
        }

        //
        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //checks to see what the current order# is
            //if (OrdersDA.getLastID() <= OrderNumber)
            //{ 
            //    OrderNumber++;
            //}
            //OrderNumber = OrdersDA.getLastID() + 1;
            OrderNumber++;
            displayMenu();
            showScreen();
            newOrder = new Order();
            newOrder.updateReciept += new Order.ListItems(recieptInfo);
            lstReceipt.Items.Clear();
            //MessageBox.Show(Convert.ToString(OrdersDA.getLastID()));
        }

        //
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                newOrder = new Order();
                newOrder.updateReciept += new Order.ListItems(recieptInfo);
                //specialsList = OrdersDA.getPromotional();
                foreach (Product n in specialsList)
                {
                    newOrder.AddItem(n);
                }
            }
            catch
            {

            }


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showScreen()
        {
            gbHolder.Visible = true;
            btnFinishOrder.Visible = true;
            btnAdd.Visible = true;
           // btnRemove.Visible = true;
            pnlMenuItems.Visible = true;
            pnlOptions.Visible = true;
        }

        private void hideScreen()
        {
            gbHolder.Visible = false;
            btnFinishOrder.Visible = false;
            btnAdd.Visible = false;
            btnRemove.Visible = false;
            pnlMenuItems.Visible = false;
            pnlOptions.Visible = false;
        }
    }
}
