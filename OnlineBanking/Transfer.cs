using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class Transfer
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        // public static string accno;
        public static string receiver_accno;
        public static string username;

        public static int amount;
        public static void transfer_check(string acc)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("select dbo.balance(@acc)", con))
                {
                    cmd.Parameters.AddWithValue("@acc", acc);
                    con.Open();
                    int balance = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("Enter receiver acc.no:");
                    receiver_accno = Console.ReadLine();
                    Console.WriteLine("Enter the amount you want to transfer: ");
                    amount = Convert.ToInt32(Console.ReadLine());
                    if (amount <= balance)
                    {
                        transfer(acc, receiver_accno, amount);
                    }
                    else
                    {
                        Console.WriteLine("Amount should be less than or equal to balance amount!!!");

                    }
                }
            }
        }
        public static void transfer(string accno, string receiver_accno, int amount)
        {

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("transfer_amt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@senderaccno", accno);
                    cmd.Parameters.AddWithValue("@receiveraccno", receiver_accno);
                    cmd.Parameters.AddWithValue("@amount", amount);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Money Transfered successfully");


                }
            }
            AddToTransfer(accno, receiver_accno, amount);

        }
        public static void AddToTransfer(string accno, string receiver_accno, int amount)
        {

            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("addtotransfer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sender_acc_no", accno);
                    cmd.Parameters.AddWithValue("@receiver_acc_no", receiver_accno);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Added to Transfers successfully");




                }
            }
        }
    }
}
