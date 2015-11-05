using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity.Migrations;

namespace EFFoo2
{
    public abstract class DataMigration<T> : IDataMigration<T>
    {
        public abstract void DataDown(MigrationBuilder migrationBuilder);
        public abstract void DataUp(MigrationBuilder migrationBuilder);
    }
}
