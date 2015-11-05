using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFFoo.Extensions
{
    public static class DbContextExtensions
    {
        // per: https://github.com/rowanmiller/UnicornStore
        public static bool AllMigrationsApplied(this DbContext context)
        {
            var historyRepo = ((IInfrastructure<IServiceProvider>)context).GetService<IHistoryRepository>();
            var migrationsAssembly = ((IInfrastructure<IServiceProvider>)context).GetService<IMigrationsAssembly>();

            var applied = historyRepo .GetAppliedMigrations().Select(m => m.MigrationId);
            var total = migrationsAssembly.Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }
    }
}
