using EFFoo2.Entities;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EFFoo.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static void EnsureMigrationsApplied(this IServiceProvider provider)
        {
            var db = provider.GetService<FooContext>().Database;
            db.Migrate();
        }

        public static void EnsureDevelopmentData(this IServiceProvider provider)
        {
            var fooContext = provider.GetService<FooContext>();
            if (fooContext.AllMigrationsApplied())
            {
                if (!fooContext.Foo.Any(f => f.Name == "Developer 1"))
                {
                    fooContext.Foo.AddRange(
                        new Customer { Name = "Developer 1" },
                        new Customer { Name = "Developer 2" },
                        new Customer { Name = "Developer 3" },
                        new Customer { Name = "Developer 4" },
                        new Customer { Name = "Developer 5" },
                        new Customer { Name = "Developer 6" },
                        new Customer { Name = "Developer 7" },
                        new Customer { Name = "Developer 8" },
                        new Customer { Name = "Developer 9" },
                        new Customer { Name = "Developer 10" }
                        );
                    fooContext.SaveChanges();
                }
            }
        }

    }
}
