using Ecommerce.Domain.Entities;
using Ecommerce.Server.Grpc.Client;
using Grpc.Net.Client;
using ReadyApp.Client.Console.Services.IServices;
using ReadyApp.Client.Console.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Services
{
    public class UserService : IUserService
    {

        public string Token { get; set; }

        public UserAuth.UserAuthClient Client { get; init; }
        public UserService(UserAuth.UserAuthClient client)
        {
            Client = client;

        }


        public void Run()
        {
            do
            {
                System.Console.WriteLine("Login - 1, Register - 2");
                var input = System.Console.ReadLine();
                if (input.ToLower().Equals("1")) Login();
                if (input.ToLower().Equals("2")) Register();
            } while (string.IsNullOrWhiteSpace(Token));

        }

        public async void Login()
        {
            var user = GetUserLogin();
            var response = await Client.UserLoginAsync(user);

            Token = response.Data;
            
            System.Console.WriteLine($"\n Successful login : {response.IsSuccessful} \n Token issed {response.Data} \n {response.Message}");
        
        }

        public async void Register()
        {
            var user = GetUserRegister();
            var response = await Client.UserRegisterAsync(user);
            System.Console.WriteLine($"\n Successful login : {response.IsSuccessful} \n {response.Data} \n {response.Message}");
        }

        private static UserLoginDto GetUserLogin()
        {
            var user = new UserLoginDto()
            {
                Token = "Token12345",
                Email = InputControl.InputOption("Email"),
                Password = InputControl.InputOption("Password")
            };
            return user;
        }

        private static UserRegisterDto GetUserRegister()
        {
            var user = new UserRegisterDto()
            {
                Token = "Token12345",
                FirstName = InputControl.InputOption("First"),
                LastName = InputControl.InputOption("Last"),
                Username = InputControl.InputOption("Username"),
                Email = InputControl.InputOption("Email"),
                Password = InputControl.InputOption("Password")
            };
            return user;
        }
    }
}
