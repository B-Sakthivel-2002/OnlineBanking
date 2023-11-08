using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class WithDraw
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static int amount;
        public static void check_acc(string acc)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("select dbo.balance(@acc)", con))
                {
                    cmd.Parameters.AddWithValue("@acc", acc);
                    con.Open();
                    int balance = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("Your account balance is : " + balance);
                    Console.WriteLine("Enter the amount you want to withdraw : ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= balance)
                    {
                        withdraw(amount, acc);
                        Console.WriteLine("Amount is withdrawn successfully!!!");
                       
                        Customer.viewbalance(acc);
                    }
                    else
                    {
                        Console.WriteLine("Amount should be less than or equal to balance amount!!!");

                    }
                }
            }
        }

        public static void withdraw(int amount, string acc)
        {

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("withdraw", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", acc);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Money withdrawed and updated successfully");


                }
            }
        }
    }
}
