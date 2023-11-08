using OnlineBanking;
using System.Security.Cryptography.X509Certificates;

class program
{
    public static void Main(String[] args)
    {   
        Console.WriteLine("Welcome To Online Banking System");
        Console.WriteLine("********************************");
        Console.WriteLine("Press 0 for Admin Login and 1 for Customer Login:");
        AdminLogin a = new AdminLogin();
        CustomerLogin c= new CustomerLogin();
        int i=Convert.ToInt32(Console.ReadLine());
        if (i == 0)
        {
            a.logincheck();
        }
        else if (i == 1)
        {
            c.userlogin();
        }
        else
        {
            Console.WriteLine("Invalid Input!!");
        }
    }
}
