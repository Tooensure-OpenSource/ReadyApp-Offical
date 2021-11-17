using Ecommerce.Server.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Services.IServices
{
    public interface IUserService
    {
        public string? Token { get; set; }
        public UserAuth.UserAuthClient Client { get; init; }
        public void Run();

        void Login();
        void Register();
    }
}
