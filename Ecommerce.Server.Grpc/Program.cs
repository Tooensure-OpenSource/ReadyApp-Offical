using Ecommerce.Data;

using Ecommerce.Server.Grpc.Services;
using Microsoft.EntityFrameworkCore;
using Tooensure.DataStructure.RepositoryPattern;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<DataContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ReadyAppDb"))
        .EnableSensitiveDataLogging()
        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

var app = builder.Build();

app.UseGrpcWeb();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<UserAuthService>();
app.MapGrpcService<BusinessService>();
app.MapGrpcService<OwnerService>();


app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
