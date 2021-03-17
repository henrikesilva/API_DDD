using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as Migrations

            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=H3nryl1m@";
            var connectionString = "Data Source=4D8MH53NMTZ;Initial Catalog=BaseDados;Integrated Security=True";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
