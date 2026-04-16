using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantityMeasurementAppRepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    Input1Value = table.Column<double>(type: "float", nullable: true),
                    Input1Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input1Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input2Value = table.Column<double>(type: "float", nullable: true),
                    Input2Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Input2Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesiredUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalValue = table.Column<double>(type: "float", nullable: true),
                    OriginalUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputValue = table.Column<double>(type: "float", nullable: true),
                    OutputUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuccessFlag = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsGoogleUser = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementRecords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
