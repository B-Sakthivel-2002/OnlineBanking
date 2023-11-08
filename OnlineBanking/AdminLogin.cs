using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace OnlineBanking
{
    internal class AdminLogin
    {
        public string username;
        public string pwd;
       
         static SqlCommand cmd;

        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        
        public void LoginUserInput()
        {
            Console.WriteLine("Enter Admin Username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter password:");

            pwd = Console.ReadLine();
            Console.WriteLine("_________________________________________________________");

        }
        public void logincheck()
        {
             
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.adminlogincheck(@username,@pwd)", con))
                {
                  
                   
                   cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        adminmenu();
                        con.Close();

                    }
                    else
                    {
                        Console.WriteLine("Admin Profile Not available!!!");
                     

                    }
                }
            }
        }

       
         public void adminmenu()
        {

            while (true)
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("Choose \n 1.Add New UserAccount \n 2.Edit Existing User Account \n 3.Remove User Account \n 4.View Single User Account Details \n 5.View All Account Details \n 6.View All Transactions \n 7.Exit");
                Console.WriteLine("What do you Need ????");
                int options = Convert.ToInt32(Console.ReadLine());
                Admin a = new Admin();
                ViewTransactions v=new ViewTransactions();
                ViewAccount o= new ViewAccount();
                switch (options)
                {

                    case 1:

                        a.AddNewAccount();
                        break;

                    case 2:
                        a.editAccount();
                        break;

                    case 3:
                        a.removeAccount();
                        break;

                    case 4:
                        o.viewSingleAccount();
                        break;

                    case 5:
                        o.viewallaccounts();
                        break;

                    case 6:
                        v.viewtranscations();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;

                }
            }
        }



    }
}
