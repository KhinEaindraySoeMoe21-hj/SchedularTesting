using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTesting.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthdayWishInfos",
                columns: table => new
                {
                    BirthdayNotiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserBd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPreBd = table.Column<bool>(type: "bit", nullable: false),
                    IsBd = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthdayWishInfos", x => x.BirthdayNotiID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplates",
                columns: table => new
                {
                    NotiTemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplates", x => x.NotiTemplateID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthdayWishInfos");

            migrationBuilder.DropTable(
                name: "NotificationTemplates");
        }
    }
}
