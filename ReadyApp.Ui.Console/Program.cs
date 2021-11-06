// See https://aka.ms/new-console-template for more information

using Ecommerce.Server.Grpc.Client;
using Grpc.Net.Client;


var user = new UserRegisterDto
{
    Username = "Frank",
    Email = "frank@gmail.com",
    Password = "1234"
};

var channel = GrpcChannel.ForAddress("http://localhost:5186");

var client = new UserAuth.UserAuthClient(channel);

var response = await client.UserRegisterAsync(user);

Console.WriteLine($"{response.Data}, {response.IsSuccessful}, {response.Message}");
