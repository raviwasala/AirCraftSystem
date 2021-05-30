using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirCrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: ""),
                    ImagePath = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, defaultValue: ""),
                    TxnDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GetDate()"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirCrafts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AirCrafts",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Location", "Make", "Model", "ModifiedDate", "Registration", "TxnDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "London Gatwick", "Boeing -1", "777-300ER", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "G-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "London Heathrow", "Boeing -2", "737 MAX", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "M-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Birmingham", "Boeing -3", "KC-767", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "K-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bristol", "Boeing -4", "B-17", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "York", "Boeing -5", "Boeing 777X", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "X-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Oxford", "Boeing -6", "Boeing 777-9", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C-RNAC", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirCrafts");
        }
    }
}
