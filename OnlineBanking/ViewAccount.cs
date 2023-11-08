using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
   
    internal class ViewAccount
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string acc;
        public void viewallaccounts()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getallaccounts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("_________________________________________________________");
                            Console.WriteLine($"Account No :{reader["acc_no"]}," + "\n" +
                                $"User Name :{reader["username"]}," + "\n" +
                                $"Gender:{reader["gender"]}," + "\n" +
                                $"Age :{reader["age"]}," + "\n" +
                                $"DateOfBirth :{reader["dob"]}," + "\n" +
                                $"Address:{reader["Adress"]}," + "\n" +
                                $"Pincode:{reader["pincode"]}," + "\n" +
                                $"Mobile :{reader["mobile_no"]}," + "\n" +
                                $"Aadhar No :{reader["aadhar_no"]}," + "\n" +
                                 $"Email :{reader["email"]}," + "\n" +
                                  $"Account Type :{reader["Account_type"]}," + "\n" +
                                   $"Balance :{reader["balance"]}," + "\n" +
                                $"IFSC Code :{reader["ifsc_code"]}");


                        }
                    }
                }

            }
        }


        public void viewSingleAccount()
        {


            Console.WriteLine("Enter the Account No :");
            acc = Console.ReadLine();
            Console.WriteLine("*************************************************");
            Console.WriteLine("Please find the property details below :");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getsingleaccountdetails", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", acc);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Account No :{reader["acc_no"]}," + "\n" +
                                  $"User Name :{reader["username"]}," + "\n" +
                                  $"Gender:{reader["gender"]}," + "\n" +
                                  $"Age :{reader["age"]}," + "\n" +
                                  $"DateOfBirth :{reader["dob"]}," + "\n" +
                                  $"Address:{reader["Adress"]}," + "\n" +
                                  $"Pincode:{reader["pincode"]}," + "\n" +
                                  $"Mobile :{reader["mobile_no"]}," + "\n" +
                                  $"Aadhar No :{reader["aadhar_no"]}," + "\n" +
                                   $"Email :{reader["email"]}," + "\n" +
                                    $"Account Type :{reader["Account_type"]}," + "\n" +
                                     $"Balance :{reader["balance"]}," + "\n" +
                                  $"IFSC Code :{reader["ifsc_code"]}");
                        }
                    }
                }


            }
        }
    }
}
