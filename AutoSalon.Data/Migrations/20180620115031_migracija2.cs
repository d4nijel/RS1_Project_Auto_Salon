using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AutoSalon.Data.Migrations
{
    public partial class migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dostava_Faktura_FakturaID",
                table: "Dostava");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodjac_Grad_SjedisteID",
                table: "Proizvodjac");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_FakturaID",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Dostava_FakturaID",
                table: "Dostava");

            migrationBuilder.DropColumn(
                name: "FakturaID",
                table: "Dostava");

            migrationBuilder.RenameColumn(
                name: "SjedisteID",
                table: "Proizvodjac",
                newName: "GradID");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvodjac_SjedisteID",
                table: "Proizvodjac",
                newName: "IX_Proizvodjac_GradID");

            migrationBuilder.RenameColumn(
                name: "Proizvodnja",
                table: "Motor",
                newName: "Potrosnja");

            migrationBuilder.AlterColumn<int>(
                name: "StatusNarudzbeID",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DostavaID",
                table: "Faktura",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_FakturaID",
                table: "Narudzba",
                column: "FakturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_DostavaID",
                table: "Faktura",
                column: "DostavaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Faktura_Dostava_DostavaID",
                table: "Faktura",
                column: "DostavaID",
                principalTable: "Dostava",
                principalColumn: "DostavaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "Narudzba",
                column: "StatusNarudzbeID",
                principalTable: "StatusNarudzbe",
                principalColumn: "StatusNarudzbeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodjac_Grad_GradID",
                table: "Proizvodjac",
                column: "GradID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faktura_Dostava_DostavaID",
                table: "Faktura");

            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "Narudzba");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvodjac_Grad_GradID",
                table: "Proizvodjac");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_FakturaID",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Faktura_DostavaID",
                table: "Faktura");

            migrationBuilder.DropColumn(
                name: "DostavaID",
                table: "Faktura");

            migrationBuilder.RenameColumn(
                name: "GradID",
                table: "Proizvodjac",
                newName: "SjedisteID");

            migrationBuilder.RenameIndex(
                name: "IX_Proizvodjac_GradID",
                table: "Proizvodjac",
                newName: "IX_Proizvodjac_SjedisteID");

            migrationBuilder.RenameColumn(
                name: "Potrosnja",
                table: "Motor",
                newName: "Proizvodnja");

            migrationBuilder.AlterColumn<int>(
                name: "StatusNarudzbeID",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "FakturaID",
                table: "Dostava",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_FakturaID",
                table: "Narudzba",
                column: "FakturaID",
                unique: true,
                filter: "[FakturaID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dostava_FakturaID",
                table: "Dostava",
                column: "FakturaID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dostava_Faktura_FakturaID",
                table: "Dostava",
                column: "FakturaID",
                principalTable: "Faktura",
                principalColumn: "FakturaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_StatusNarudzbe_StatusNarudzbeID",
                table: "Narudzba",
                column: "StatusNarudzbeID",
                principalTable: "StatusNarudzbe",
                principalColumn: "StatusNarudzbeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvodjac_Grad_SjedisteID",
                table: "Proizvodjac",
                column: "SjedisteID",
                principalTable: "Grad",
                principalColumn: "GradID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
