using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zdt_application.Auth;
using zdt_application.Models;

namespace zdt_application.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PinnedLeagues> PinnedLeagues { get; set; }
        public DbSet<UserLeague> UserPinnedLeagues { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserMatchPrediction> UserMatchPredictions { get; set; }
        public DbSet<MatchRating> MatchRatings { get; set; }
        public DbSet<MostClickedMatch> ClickedMatches { get; set; }
        public DbSet<UserResultPrediction> UserResultPredictions { get; set; }
        public DBContext()
        {

        }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLeague>()
                .HasKey(upl => new { upl.UserId, upl.PinnedLeaguesId });

            modelBuilder.Entity<UserLeague>()
                .HasOne(u => u.PinnedLeagues)
                .WithMany(p => p.UserPinnedLeagues)
                .HasForeignKey(upl => upl.UserId);

            modelBuilder.Entity<UserLeague>()
                .HasOne(upl => upl.PinnedLeagues)
                .WithMany(pl => pl.UserPinnedLeagues)
                .HasForeignKey(upl => upl.PinnedLeaguesId);

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
