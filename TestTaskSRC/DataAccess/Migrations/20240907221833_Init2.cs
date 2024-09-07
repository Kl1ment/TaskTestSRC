using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_Cabinet",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Districts_District",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specifications_Specification",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_District",
                table: "Patients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Specifications_Name",
                table: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Patients_District",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Cabinet",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_District",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Specification",
                table: "Doctors");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Districts_Number",
                table: "Districts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Cabinets_Number",
                table: "Cabinets");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Cabinet",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                table: "Patients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CabinetId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DistrictId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecificationId",
                table: "Doctors",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DistrictId",
                table: "Patients",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DistrictId",
                table: "Doctors",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecificationId",
                table: "Doctors",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_CabinetId",
                table: "Doctors",
                column: "CabinetId",
                principalTable: "Cabinets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Districts_DistrictId",
                table: "Doctors",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specifications_SpecificationId",
                table: "Doctors",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_DistrictId",
                table: "Patients",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Cabinets_CabinetId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Districts_DistrictId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specifications_SpecificationId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Districts_DistrictId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DistrictId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CabinetId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DistrictId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecificationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecificationId",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Specifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "District",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Cabinet",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "District",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Specifications_Name",
                table: "Specifications",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Districts_Number",
                table: "Districts",
                column: "Number");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Cabinets_Number",
                table: "Cabinets",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_District",
                table: "Patients",
                column: "District");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Cabinet",
                table: "Doctors",
                column: "Cabinet");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_District",
                table: "Doctors",
                column: "District");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Specification",
                table: "Doctors",
                column: "Specification");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_Cabinet",
                table: "Doctors",
                column: "Cabinet",
                principalTable: "Cabinets",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Districts_District",
                table: "Doctors",
                column: "District",
                principalTable: "Districts",
                principalColumn: "Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specifications_Specification",
                table: "Doctors",
                column: "Specification",
                principalTable: "Specifications",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_District",
                table: "Patients",
                column: "District",
                principalTable: "Districts",
                principalColumn: "Number");
        }
    }
}
