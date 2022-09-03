using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phantom.API.Migrations
{
    public partial class Innitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsappNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTPExpiry = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ResetTokenExpiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VerificationTokenExpiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAgent = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastPasswordChange = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastLoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LoginDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PasswordChangeDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    isVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsDefaultPassword = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
