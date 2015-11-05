using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFFoo2.DataMigrations
{
    public static class MigrationBuilderExtensions
    {
        public static void InitialDataUp(this MigrationBuilder migration /* add any extra options required for this operation */)
        {
            Console.WriteLine("Running DataUp for Migration Initial");

            /* Using 2 migration operations for readability... plan is to move to a single operation - which is read from an embedded resource */
            migration.Operations.Add(new SqlOperation
            {
                Sql = @"INSERT INTO [Customer] ([Name])  VALUES ('Customer 1');
                        INSERT INTO [Customer] ([Name])  VALUES ('Customer 2');"
            });

            migration.Operations.Add(new SqlOperation
            {
                Sql = @"INSERT INTO [Supplier] ([Name])  VALUES ('Supplier 1');
                        INSERT INTO [Supplier] ([Name])  VALUES ('Supplier 2');"
            });
        }
        public static void InitialDataDown(this MigrationBuilder migration)
        {
            Console.WriteLine("Running DataDown for Migration Initial");

            /* It may not actually make sense to have down operations for statements which simply added some data */
            migration.Operations.Add(new SqlOperation
            {
                Sql = @"DELETE FROM [Customer] WHERE [Name] == 'Customer 1';
                        DELETE FROM [Customer] WHERE [Name] == 'Customer 2';"
            });

            migration.Operations.Add(new SqlOperation
            {
                Sql = @"DELETE FROM [Supplier] WHERE [Name] == 'Supplier 1';
                        DELETE FROM [Supplier] WHERE [Name] == 'Supplier 2';"
            });
        }
    }

}
