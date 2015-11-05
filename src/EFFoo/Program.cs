using EFFoo.Extensions;
using EFFoo2.Entities;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;

namespace EFFoo
{
    public class Program
    {

        public readonly IConfiguration Configuration;
        private readonly IServiceProvider serviceProvider;


        public Program(IApplicationEnvironment env)
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json");

            Configuration = builder.Build();
            
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            Configure(serviceProvider);
        }



        public void Main(string[] args)
        {

            Console.WriteLine("Completed");
            Console.ReadKey();
        }


        private void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];
            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<FooContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                }
                );
            // services.AddScoped<FooContext>();
        }


        public void Configure(IServiceProvider provider)
        {
            // per 'Pattern for seeding database with EF7 in ASP.NET 5': 
            // https://github.com/aspnet/EntityFramework/issues/3070
            provider.EnsureMigrationsApplied();
            provider.EnsureDevelopmentData();
        }

    }
}
