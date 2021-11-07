using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Pages.Authentication
{
    public static class AuthController
    {
        public static void Init(string httpRoute)
        {
            do
            {

                System.Console.WriteLine("Login : 1, Register : 2");
                var option = System.Console.ReadLine();
                if (option == "1")
                {
                    AuthLogin(httpRoute);
                }
                else if (option == "2") AuthRegister(httpRoute);

            } while (!Login.LoginSuccessful);
            if (Login.LoginSuccessful) System.Console.WriteLine("Login Successful");
        }

        public static void AuthLogin(string httpRoute)
        {
            System.Console.WriteLine("Login");
            Login.Init(httpRoute);
        }
        public static void AuthRegister(string httpRoute)
        {
            System.Console.WriteLine("Register");
            Register.Init(httpRoute);
        }
    }
}
