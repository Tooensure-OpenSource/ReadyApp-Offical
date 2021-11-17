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
    public class BusinessService : IBusinessService
    {
        public static string Token { get; set; }

        public BusinessDto.BusinessDtoClient Client { get; init; }
        public BusinessService(BusinessDto.BusinessDtoClient client)
        {
            Client = client;
        }


        public void Run(string token)
        {
            Token = token;
            do
            {
                System.Console.WriteLine("Register Business- 1");
                var input = System.Console.ReadLine();
                if (input.ToLower().Equals("1")) Register();
            } while (!string.IsNullOrWhiteSpace(Token));
        }

        public async void Register()
        {
            var user = GetBusinessRegister();
            var response = await Client.BusinessRegisterAsync(user);
            System.Console.WriteLine($"\n Successful login : {response.Successful} \n {response.Data}");
        }


        private static BusinessRegisterDto GetBusinessRegister()
        {
            var business = new BusinessRegisterDto()
            {
                UserId = Token,
                Name = InputControl.InputOption("Name"),
                Username = InputControl.InputOption("Username"),
            };
            return business;
        }
    }
}
