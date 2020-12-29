using API.Data.Context;
using API.Data.Implementations;
using API.Data.Repository;
using API.Domain.Interfaces;
using API.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.CrossCutting.DependecyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                //options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=H3nryl1m@")
                options => options.UseSqlServer("Data Source=DESKTOP-3NBE5J3;Initial Catalog=dbapi;Integrated Security=True")
            );
        }
    }
}
