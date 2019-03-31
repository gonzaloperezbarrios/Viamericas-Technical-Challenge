namespace Api.Test.API.DependencyInjection
{
    //using AutoMapper;
    using Api.Test.Infrastructure.Data.DBFactory;
    using Api.Test.Infrastructure.Data.EntityFramework;
    using Api.Test.Infrastructure.Data.Repositories;
    using Api.Test.Infrastructure.Framework.Instrumentation.Logging;
    using Api.Test.Infrastructure.Framework.RepositoryPattern;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.MSSqlServer;
    using System.Collections.ObjectModel;
    using System.Data;
    using Api.Test.Application.Services.Agency;
    using GraphQL;
    using GraphQL.Server.Transports.AspNetCore;
    using GraphQL.Server.Transports.WebSockets;
    using graph=Api.Test.Client;

    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Resolver la dependencia de los servicios
        /// </summary>
        /// <param name="services"></param>
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
     
            services.AddSingleton(configuration);

            //Domain
            //Repositories
            // Infrastructure
            // Infra - Data
            services.AddSingleton<IDatabaseFactory, DatabaseFactory>();
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

          
            // Application

            services.AddSingleton<IAgencyService, AgencyService>();




            //Auth0
            //services.AddSingleton<IAuthorizationHandler, HasChannelAuthorizationHandler>();

            /////////////////GraphQL////////////////// 
            services.AddSingleton<graph.Services.IAgencyService, graph.Services.AgencyService>();
            services.AddSingleton<graph.Schemas.AgencyType>();
            services.AddSingleton<graph.Schemas.CityType>();
            services.AddSingleton<graph.Schemas.StateType>();
            services.AddSingleton<graph.Schemas.CityOfAgencyType>();
            services.AddSingleton<graph.Schemas.AgencyQuery>();
            services.AddSingleton<graph.Schemas.AgencySchema>();
            services.AddSingleton<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<graph.Schemas.AgencySchema>();

            //services.AddScoped<DbContext>(sp => sp.GetService<DBContext>());

            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

        }
    }
}
