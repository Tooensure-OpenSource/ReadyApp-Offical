using Ecommerce.Server.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyApp.Client.Console.Services.IServices
{
    public interface IBusinessService
    {
        public BusinessDto.BusinessDtoClient Client { get; init; }
        public void Run(string token);
        void Register();
    }
}
