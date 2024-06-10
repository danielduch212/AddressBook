using AddressBook.Infrastructure.Repository;
using AddressBook.Infrastructure.Seeders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace AddressBook.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IAddressBookRepository, AddressBookRepository>();
            services.AddSingleton<IAddressBookSeeder, AddressBookSeeder>();

        }
    }
}
