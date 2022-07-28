using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffScheduler.Migrations
{
    public partial class UpdateEntitiesDir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Staff_StaffId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "Schedules",
                newName: "StaffEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StaffId",
                table: "Schedules",
                newName: "IX_Schedules_StaffEntityId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Schedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Schedules",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Staff_StaffEntityId",
                table: "Schedules",
                column: "StaffEntityId",
                principalTable: "Staff",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Staff_StaffEntityId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "StaffEntityId",
                table: "Schedules",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StaffEntityId",
                table: "Schedules",
                newName: "IX_Schedules_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Staff_StaffId",
                table: "Schedules",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
