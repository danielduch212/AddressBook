using AddressBook.Infrastructure.Extensions;
using AddressBook.Infrastructure.Repository;
using AddressBook.Infrastructure.Seeders;



var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();





builder.Services.AddInfrastructureServices();


var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IAddressBookSeeder>();

seeder.SeedData();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
