using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class Customer
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
       // public static string accno;
        public static string receiver_accno;
        public static string username;
       


        public static int amount;//used in deposit
        public static void viewbalance(string acc)
        {
            Console.WriteLine("*********************************************************");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getbalance", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", acc);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Balance amount in your account:{reader["balance"]}");
                            
                        }
                    }
                }
                

            }
          
        }
     
       
        

       

       

      
    }
}
