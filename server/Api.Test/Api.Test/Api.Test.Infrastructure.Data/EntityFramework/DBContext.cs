namespace Api.Test.Infrastructure.Data.EntityFramework
{
    using Api.Test.Domain.Entities.Agency;
    using Api.Test.Domain.Entities.Agency.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;

    public class DBContext : DbContext, IDisposable
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //var serviceProvider = ((IInfrastructure<IServiceProvider>)this).Instance;
                //var config = this.GetService<IConfigurationRoot>();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


                // get the configuration from the app settings
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env}.json", optional: true)
                    .Build();


                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            #region Agency
            modelBuilder.Entity<Agency>().HasKey(vf => new { vf.Id });          
            #endregion   

            #region State
            modelBuilder.Entity<State>().HasKey(vf => new { vf.Id });
            #endregion   

            #region City
            modelBuilder.Entity<City>().HasKey(vf => new { vf.Id });
            #endregion  
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
    }
}
