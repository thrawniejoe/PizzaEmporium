using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PizzaEmporium
{

    

    class OrdersDA //gets a list of sizes for pizza's and drinks
    {
        public static SqlConnection GetConnection()
        {
            //home
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Thrawntl_PC\\OneDrive\\Adv C#\\Program 3\\PizzaEmporium\\PizzaEmporium\\Orders.mdf;Integrated Security=True";
            
            //work
            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\xvelasjo.NTDOMAIN\\OneDrive\\Adv C#\\Program 3\\PizzaEmporium\\PizzaEmporium\\Orders.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public static void AddOrder(Order newOrder)
        {
            //ex : insert into [dbo].[Table] (Id, Date, BranchName, TotalOfOrder) VALUES (100, '11/20/2015', 'Joe Velasquez', 95.50)
            SqlConnection connection = GetConnection();
            string insertStatement = "INSERT INTO [dbo].[Orders](Date, BranchName, TotalOfOrder) Values (@Date, @BranchName, @TotalOfOrder)";

            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                //insertCommand.Parameters.AddWithValue("@Id", getLastID() +1);
                insertCommand.Parameters.AddWithValue("@Date", newOrder.Date);
                insertCommand.Parameters.AddWithValue("@BranchName", newOrder.Branch);
                insertCommand.Parameters.AddWithValue("@TotalOfOrder", newOrder.Price);

                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                
            }
            finally
            {  
                connection.Close();
            }
        }


        public static void AddProductToDB(Product p)
        {
            //ex : insert into [dbo].[Table] (Id, Date, BranchName, TotalOfOrder) VALUES (100, '11/20/2015', 'Joe Velasquez', 95.50)
            SqlConnection connection = GetConnection();
            string insertStatement = "INSERT INTO [dbo].[Orders](Date, BranchName, TotalOfOrder, Item) Values (@Date, @BranchName, @TotalOfOrder, @Item)";

            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                insertCommand.Parameters.AddWithValue("@Item", p.Id);
                insertCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                insertCommand.Parameters.AddWithValue("@BranchName", "Joe Velasquez");
                insertCommand.Parameters.AddWithValue("@TotalOfOrder", p.Price);
                //insertCommand.Parameters.AddWithValue("@OrderID", p.getId);
                insertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                connection.Close();
            }
        }

        public static int getLastID() //Counts the number of records in table
        {
            //int lastId = 0;
            int results = 0;

            SqlConnection connection = GetConnection();
            //string fetchStatement = "SELECT Id FROM [dbo].[Table] WHERE Id = '" + id + "'";
            string countRec = "SELECT COUNT(Id) FROM [dbo].[Orders]";
            try
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand(countRec, connection);

                results = insertCommand.ExecuteNonQuery();
               // if (results <= id)
               // {
                //    return results;
                //}
                
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return results;
        }

        //List of Sizes of items
        public static List<Sizes> GetAllSizes()
        {
            List<Sizes> allSizes = new List<Sizes>();
            allSizes.Add(new Sizes("Small", 4.99, 1.50));
            allSizes.Add(new Sizes("Medium", 6.99, 2.00));
            allSizes.Add(new Sizes("Large", 9.99, 2.50));
            return allSizes;
        }


        //List of items that can be added on to a pizza
        public static List<AddOns> GetDrinkAddOns()
        {
            List<AddOns> drinkAddOn = new List<AddOns>();
            drinkAddOn.Add(new AddOns("Mt Dew", 1.45));
            drinkAddOn.Add(new AddOns("Coke", 1.60));
            drinkAddOn.Add(new AddOns("Pepsi", .55));
            drinkAddOn.Add(new AddOns("Mellow Yellow", .56));
            drinkAddOn.Add(new AddOns("Mixed Coke", .53));
            return drinkAddOn;
        }

        //List of items that can be added on to a pizza
        public static List<AddOns> GetAddOns()
        {
            List<AddOns> addOn = new List<AddOns>();
            addOn.Add(new AddOns("Extra Cheeze", 1.45));
            addOn.Add(new AddOns("Hamburger",1.60));
            addOn.Add(new AddOns("Greeen Pepper", .15));
            addOn.Add(new AddOns("Black Olive", .26));
            addOn.Add(new AddOns("Veggie", .33));
            addOn.Add(new AddOns("Pineapple", .40));
            return addOn;
        }

        //Menu List
        public static List<String> GetMenuItems()
        {
            List<String> menuItems = new List<String>();
            menuItems.Add("Pizza");
            menuItems.Add("Drinks");
            menuItems.Add("Salads");
            menuItems.Add("Specials");
            menuItems.Add("Cool Stuff");
            return menuItems;
        }


        public static List<Salads> GetSalads()
        {
            List<Salads> salad = new List<Salads>();
            salad.Add(new Salads("Garden", 4.45));
            salad.Add(new Salads("Chef", 3.60));
            salad.Add(new Salads("Ceaser", 6.15));
            salad.Add(new Salads("Chicken", 5.26));
            salad.Add(new Salads("Chilean", 8.33));
            salad.Add(new Salads("Da Big Ass Combo Salad", 34.40));
            return salad;
        }

        public static List<Promotional> getPromotional()
        {
            List<Promotional> promo = new List<Promotional>();
            promo.Add(new Promotional("T-Shirt Tweet", 14.55));
            promo.Add(new Promotional("T-Shirt Swag", 24.55));
            promo.Add(new Promotional("T-Shirt JoCool", 34.55));
            return promo;
        }


        public static List<Order> getSpeicals()
        {
            List<Order> Special = new List<Order>();
            //Special.Add(new Order());
            return Special;
        }
        

        public static List<Product> getSpecials()
        {
            List<Product> newOrder = new List<Product>();

            List<AddOns> addOn = GetAddOns();
            List<Sizes> allSizes = GetAllSizes();

            Drink newDrink = new Drink();
            Pizza newPizza = new Pizza();
            newPizza.Id = "Large Supreme Pizza";
            
            newPizza.pickSize(allSizes[2]);
            newPizza.setAddon(addOn[4]);
            newPizza.setAddon(addOn[3]);
            newPizza.setAddon(addOn[1]);
            newDrink.pickSize(allSizes[2]);
            newDrink.Id = "Large Drink";
            newOrder.Add(newPizza);
            newOrder.Add(newDrink);
            
            
            return newOrder;
        }
    }
}
