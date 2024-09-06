using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCascase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

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

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Specification",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Cabinet",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

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

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Specification",
                table: "Doctors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "District",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cabinet",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Cabinets_Cabinet",
                table: "Doctors",
                column: "Cabinet",
                principalTable: "Cabinets",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Districts_District",
                table: "Doctors",
                column: "District",
                principalTable: "Districts",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specifications_Specification",
                table: "Doctors",
                column: "Specification",
                principalTable: "Specifications",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Districts_District",
                table: "Patients",
                column: "District",
                principalTable: "Districts",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
