// See https://aka.ms/new-console-template for more information
using ReadyApp.Client.Console;
using ReadyApp.Client.Console.Settings;

Console.WriteLine("The Ready App | From Tooensure");
//AuthController.Init("http://localhost:5186");

UnitOfWork channel = new("http://localhost:5186");
channel.Run();

