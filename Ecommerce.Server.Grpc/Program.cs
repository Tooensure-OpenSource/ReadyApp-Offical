using Ecommerce.Data;
using Ecommerce.Data.Repositories.IRepositories.IUserRepositories;
using Ecommerce.Data.Repositories.UserRepositories;
using Ecommerce.Server.Grpc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();

builder.Services.AddDbContext<DataContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ReadyAppDb"))
        .EnableSensitiveDataLogging()
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<UserAuthService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();