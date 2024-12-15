using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CropCommander.Common.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    FieldName = table.Column<string>(type: "text", nullable: false),
                    FieldArea = table.Column<double>(type: "double precision", nullable: false),
                    CropName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fields");
        }
    }
}
