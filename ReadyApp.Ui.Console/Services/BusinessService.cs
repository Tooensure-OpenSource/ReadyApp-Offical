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
        public Business Business { get; set; } = new Business();
        public bool BusinessAccess { get; set; } = false;
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
                System.Console.WriteLine("Register Business - 1, Search - 2");
                var input = System.Console.ReadLine();
                if (input.ToLower().Equals("1")) Register();
                if (input.ToLower().Equals("2")) Search();
                if(BusinessAccess)
                {
                    System.Console.WriteLine($"You have a accessed business {Business.BusinessId}");
                    System.Console.WriteLine("Owners - 1");
                    var businessInput = System.Console.ReadLine();
                    if (businessInput.ToLower().Equals("1")) OwnerService.GetOwners();

                }
            } while (!string.IsNullOrWhiteSpace(Token));
        }

        public async void Register()
        {
            var user = GetBusinessRegister();
            var response = await Client.BusinessRegisterAsync(user);
            System.Console.WriteLine($"\n Successful login : {response.Successful} \n {response.Data}");
        }

        public async void Search()
        {
            var user = GetBusinessUsernameSearchInput();
            var response = await Client.BusinessSearchAsync(user);
            System.Console.WriteLine($"\nSearch results : {response.Successful} \n {response.Data} \n {response.Message}");
            if (response.Successful) Business = new Business(Guid.Parse(response.Data)); BusinessAccess = true;
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

        private static BusinessUsernameDto GetBusinessUsernameSearchInput()
        {
            var business = new BusinessUsernameDto()
            {
                Username = InputControl.InputOption("Username")
            };
            return business;
        }


        public void Access(bool condition, string data)
        {
            if(condition)
            {
                System.Console.WriteLine("Do what to Select this busines y/n");
                var input = System.Console.ReadLine();
                if (input.ToLower().Equals("y"))
                {
                    System.Console.WriteLine("dsSdsddd");
                    Business = new(Guid.Parse(data));
                    System.Console.WriteLine($"You have accessed {Business.BusinessId}");
                };
            }
        }
    }

}
