using Microsoft.Data.Entity.Migrations;

namespace EFFoo2
{
    public interface IDataMigration<T>
    {
        void DataDown(MigrationBuilder migrationBuilder);
        void DataUp(MigrationBuilder migrationBuilder);
    }
}
