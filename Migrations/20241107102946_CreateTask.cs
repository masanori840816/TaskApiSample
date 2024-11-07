using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskApiSample.Migrations
{
    /// <inheritdoc />
    public partial class CreateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(128)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdateDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET() AT TIME ZONE 'Tokyo Standard Time'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "task");
        }
    }
}
