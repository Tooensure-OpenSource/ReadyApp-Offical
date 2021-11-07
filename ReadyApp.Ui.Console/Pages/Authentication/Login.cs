using Ecommerce.Domain.Entities;
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
    public static class Login
    {
        public static string? Token { get; set; }
        public static bool LoginSuccessful { get; set; } = false;


        public async static void Init(string httpRoute)
        {
            var user = RegisterUser();

            var channel = GrpcChannel.ForAddress(httpRoute);

            var client = new UserAuth.UserAuthClient(channel);

            var response = await client.UserLoginAsync(user);

            if (response.IsSuccessful)
            {
                Token = response.Data;
                LoginSuccessful = response.IsSuccessful;
            }

            System.Console.WriteLine($"Successful : {response.IsSuccessful}");
            System.Console.WriteLine($"{Token} {response.Message}");
        }

        private static UserLoginDto RegisterUser()
        {
            var user = new UserLoginDto
            {
                Email = InputControl.InputOption("Email"),
                Password = InputControl.InputOption("Password")
            };
            return user;
        }

    }
}
