using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class ViewTransactions
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";

        public void viewtranscations()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("adminviewtransactions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("_________________________________________________________");
                            Console.WriteLine($"Sender Account No :{reader["sender_acc_no"]}," + "\n" +

                                  $"Receiver Account No :{reader["receiver_acc_no"]}," + "\n" +
                                   $"Amount :{reader["amount"]}," + "\n" +
                                $"Date :{reader["cdate"]}");


                        }
                    }
                }

            }

        }
        public static void ViewAllTransactions(string accno)
        {
            Console.WriteLine("_________________________________________________________");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("viewalltransactions", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", accno);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Sender Account No :{reader["sender_acc_no"]}," + "\n" +

                                   $"Receiver Account No :{reader["receiver_acc_no"]}," + "\n" +
                                    $"Amount :{reader["amount"]}," + "\n" +
                                 $"Date :{reader["cdate"]}");
                            Console.WriteLine("_________________________________________________________");
                        }

                    }
                }


            }
        }
    }
}
