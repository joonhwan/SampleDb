using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SampleDb.Chinook.Utils;

namespace SampleDb.Chinook.PostgreSQL.Migrations;

public partial class Initial
{
    private List<MigrationOperation>? _upOps;
    private string? _sqlToSeed;

    public override IReadOnlyList<MigrationOperation> UpOperations
    {
        get
        {
            if (_upOps is null)
            {
                var migrationBuilder = new MigrationBuilder(ActiveProvider);
                Up(migrationBuilder);
                UpCustom(migrationBuilder);
                _upOps = migrationBuilder.Operations;
            }
            return _upOps;
        }
    }

    private void UpCustom(MigrationBuilder builder)
    {
        _sqlToSeed ??= this.GetType().Assembly.ReadResource("chinook-seed.sql");
        if (_sqlToSeed is not null)
        {
            builder.Sql(_sqlToSeed);
        }
    }
}