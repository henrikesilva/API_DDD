using System;
using API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace API.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider serviceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o =>
                //o.UseSqlServer($"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=rique;PassWord=H3nryl1m@"),
                o.UseSqlServer($"Data Source=4D8MH53NMTZ;Initial Catalog={dataBaseName};Integrated Security=True"),
                  ServiceLifetime.Transient
            );

            serviceProvider = serviceCollection.BuildServiceProvider();
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = serviceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
