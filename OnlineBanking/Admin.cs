using Azure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking
{
    internal class Admin
    {
        public static string connectionString = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=Banking;Persist Security Info=True;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public static string accno;
        public static string pwd;
        public static string username;
        public static string gender;
        public static int age;
        public static string dob;
        public static string Address;
        public static string pincode;
        public static string mobileNo;
        public static string Aadharno;
        public static string email;
        public static string accountType;
        public static int balance ;
        public static string ifsc;
        public static string acc; //used in single account fetch
        public void GetUserInput()
        {
            Console.WriteLine("Enter the Account number :");
            accno = Console.ReadLine();

            Console.WriteLine("Enter the user name :");
            username = Console.ReadLine();

            Console.WriteLine("Enter the pin :");
            pwd = Console.ReadLine();

            Console.WriteLine("Enter the gender :");
            gender = Console.ReadLine();

            Console.WriteLine("Enter the age:");
            age=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter DOB:");
            dob = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();

            Console.WriteLine("Enter pincode:");
            pincode = Console.ReadLine();

            Console.WriteLine("Enter Mobile No:");
            mobileNo = Console.ReadLine();

            Console.WriteLine("Enter Aadhar No:");
            Aadharno = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            email = Console.ReadLine();

            Console.WriteLine("Enter Account Type:");
            accountType= Console.ReadLine();

            balance = 0;

            Console.WriteLine("Enter IFSC Code:");
            ifsc = Console.ReadLine();
        }
        public void AddNewAccount()
        {
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("addaccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", accno);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@adress", Address);
                    cmd.Parameters.AddWithValue("@pincode",pincode);
                    cmd.Parameters.AddWithValue("@mobile_no", mobileNo);
                    cmd.Parameters.AddWithValue("@aadhar_no", Aadharno);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Account_type", accountType);
                    cmd.Parameters.AddWithValue("@balance", balance);
                    cmd.Parameters.AddWithValue("@ifsc_code",ifsc);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Account details successfully added");
             



                }
            }
        }
       ViewAccount l= new ViewAccount();
       
        public void editAccount()
        {
            l.viewSingleAccount();
            Console.WriteLine("Please enter the details to be updated");
            GetUserInputabc();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("editAccount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@acc_no", acc);
                   
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@dob", dob);
                    cmd.Parameters.AddWithValue("@adress", Address);
                    cmd.Parameters.AddWithValue("@pincode", pincode);
                    cmd.Parameters.AddWithValue("@mobile_no", mobileNo);
                    cmd.Parameters.AddWithValue("@aadhar_no", Aadharno);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@Account_type", accountType);
                    cmd.Parameters.AddWithValue("@ifsc_code", ifsc);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Account details successfully updated");


                }
            }
        }

        public void removeAccount()
        {

            l.viewSingleAccount();

            Console.WriteLine("Are you sure that you want to delete this Account ? (Y /N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("deleteaccount", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@acc_no", acc);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Account successfully deleted");
            }
            else
            {
                Console.WriteLine("Account not deleted ");
                ViewAccount v=new ViewAccount();
                v.viewallaccounts();
            }
        }
        


        public void GetUserInputabc()
        {
            Console.WriteLine("Enter acc no:");
            acc = Console.ReadLine();

            Console.WriteLine("Enter the user name :");
            username = Console.ReadLine();
             
            Console.WriteLine("Enter the gender :");
            gender = Console.ReadLine();

            Console.WriteLine("Enter the age:");
            age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter DOB:");
            dob = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();

            Console.WriteLine("Enter pincode:");
            pincode = Console.ReadLine();

            Console.WriteLine("Enter Mobile No:");
            mobileNo = Console.ReadLine();

            Console.WriteLine("Enter Aadhar No:");
            Aadharno = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            email = Console.ReadLine();

            Console.WriteLine("Enter Account Type:");
            accountType = Console.ReadLine();

            balance = 0;

            Console.WriteLine("Enter IFSC Code:");
            ifsc = Console.ReadLine();
        }

    }
}
