using Ecommerce.Server.Grpc.Client;
using Grpc.Net.Client;
using ReadyApp.Client.Console.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Pages.Authentication
{
    public static class Register
    {
        public static string Token { get; set; }
        public static bool RegisterSuccessful { get; set; }
        public async static void Init(string httpRoute)
        {
            var user = RegisterUser();

            var channel = GrpcChannel.ForAddress(httpRoute);

            var client = new UserAuth.UserAuthClient(channel);

            var response = await client.UserRegisterAsync(user);

            if (response.IsSuccessful)
            {
                Token = response.Data;
                RegisterSuccessful = response.IsSuccessful;
            }

            System.Console.WriteLine($"Successful : {response.IsSuccessful}");
            System.Console.WriteLine($"{response.Data} {response.Message}");
        }

        private static UserRegisterDto RegisterUser()
        {
            var user = new UserRegisterDto
            {
                FirstName = InputControl.InputOption("First Name"),
                LastName = InputControl.InputOption("Last Name"),
                Username = InputControl.InputOption("Username"),
                Email = InputControl.InputOption("Email"),
                Password = InputControl.InputOption("Password")
            };
            return user;
        }

    }
}
