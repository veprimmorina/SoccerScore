using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zdt_application.Auth;

namespace zdt_application.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var AppName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppName);
                //optionsBuilder.UseSqlServer("Data Source=SQL5105.site4now.net;Initial Catalog=db_a7ac86_skena;User ID=db_a7ac86_skena_admin;Password=Sk3n@2022");
            }
        }
    }
}
