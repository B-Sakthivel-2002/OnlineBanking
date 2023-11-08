using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class CustomerLogin
    {
        public static string accno;
        public string pin;
        static SqlCommand cmd;

        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        public void userlogin()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserCustomerInput();

                using (var cmd = new SqlCommand("select dbo.userlogincheck(@accno,@pin)", con))
                {
                    cmd.Parameters.AddWithValue("@accno", accno);
                    cmd.Parameters.AddWithValue("@pin", pin);


                    con.Open();
                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {

                        Console.WriteLine("welcome User");
                        usermenu();
                        con.Close();

                    }
                    else
                    {
                        Console.WriteLine("Account No or Password is wrong!!!");


                    }
                }

            }
        }

        public void LoginUserCustomerInput()
        {
            Console.WriteLine("Enter account no:");
            accno = Console.ReadLine();
            Console.WriteLine("Enter pin:");
            pin = Console.ReadLine();
            Console.WriteLine("_________________________________________________________");
        }
        public static void usermenu()
        {

            while (true)
            {
                Console.WriteLine("*********************************************************");
                Console.WriteLine("Choose \n 1.View Balance \n 2.Deposit \n 3.Withdraw \n 4.Transfer \n 5.View Transactions \n 6.Exit");
                Console.WriteLine("What do you Need ????");
                int options = Convert.ToInt32(Console.ReadLine());
                Customer c = new Customer();
                switch (options)
                {
                    case 1:
                        Customer.viewbalance(accno);
                        break;
                    case 2:
                        Deposits.deposit(accno);
                        break;
                    case 3:
                        WithDraw.check_acc(accno);
                        break;
                    case 4:
                        Transfer.transfer_check(accno);
                        break;
                    case 5:
                        ViewTransactions.ViewAllTransactions(accno);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    case 7:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
