using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class Deposits
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static int amount;
        public static void deposit(string acc)
        {
            Console.WriteLine("Enter the deposit Amount:");
            amount = Convert.ToInt32(Console.ReadLine());
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("deposit", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", acc);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Money Deposited successfully");


                }
            }
        }
    }
}
