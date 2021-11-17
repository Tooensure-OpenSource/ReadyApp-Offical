using Ecommerce.Server.Grpc.Client;
using Grpc.Net.Client;
using ReadyApp.Client.Console.Services;
using ReadyApp.Client.Console.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console
{
    public class UnitOfWork
    {
        public UnitOfWork(string address)
        {
            // Setting up grpc client configurations
            var channel = GrpcChannel.ForAddress(address);
            var client = new UserAuth.UserAuthClient(channel);
            var businessClient = new BusinessDto.BusinessDtoClient(channel);

            User = new UserService(client);
            Business = new BusinessService(businessClient);
        }

        public IUserService User { get; }
        public IBusinessService Business { get; }


        public void Run()
        {
            User.Run();
            Business.Run(User.Token);

        }
    }
}
