using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PostgresEFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    CodeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Nit = table.Column<long>(nullable: false),
                    GIn = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.CodeId);
                    table.ForeignKey(
                        name: "FK_Enterprises_Codes_CodeId",
                        column: x => x.CodeId,
                        principalTable: "Codes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Codes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description 1", "Code 1" },
                    { 2, "Description 2", "Code 2" },
                    { 3, "Description 3", "Code 3" },
                    { 4, "Description 4", "Code 4" }
                });

            migrationBuilder.InsertData(
                table: "Enterprises",
                columns: new[] { "CodeId", "GIn", "Id", "Name", "Nit" },
                values: new object[,]
                {
                    { 1, 9223372036854775805L, 1, "Owner 1", 9223372036854775804L },
                    { 2, 9223372036854775806L, 2, "Owner 2", 9223372036854775803L },
                    { 3, 9223372036854775802L, 3, "Owner 3", 9223372036854775801L },
                    { 4, 9223372036854775805L, 1, "Owner 1", 9223372036854775804L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropTable(
                name: "Codes");
        }
    }
}
