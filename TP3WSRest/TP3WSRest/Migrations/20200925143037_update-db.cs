using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3WSRest.Migrations
{
    public partial class updatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAVORI_COMPTE",
                schema: "public",
                table: "Favoris");

            migrationBuilder.DropForeignKey(
                name: "FK_FAVORI_FILM",
                schema: "public",
                table: "Favoris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Film",
                schema: "public",
                table: "Film");

            migrationBuilder.DropPrimaryKey(
                name: "pk_avis",
                schema: "public",
                table: "Favoris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comptes",
                schema: "public",
                table: "Comptes");

            migrationBuilder.RenameTable(
                name: "Film",
                schema: "public",
                newName: "T_E_FILM_FLM",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Favoris",
                schema: "public",
                newName: "T_J_FAVORI_FAV",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Comptes",
                schema: "public",
                newName: "T_E_COMPTE_CPT",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Favoris_FLM_ID",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                newName: "IX_T_J_FAVORI_FAV_FLM_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Comptes_CPT_MEL",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                newName: "IX_T_E_COMPTE_CPT_CPT_MEL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 25, 16, 30, 36, 901, DateTimeKind.Local).AddTicks(4716),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 9, 25, 11, 31, 3, 169, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_E_FILM_FLM",
                schema: "public",
                table: "T_E_FILM_FLM",
                column: "FLM_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAV",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                columns: new[] { "CPT_ID", "FLM_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_E_COMPTE_CPT",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                column: "CPT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FAV_CPT",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                column: "CPT_ID",
                principalSchema: "public",
                principalTable: "T_E_COMPTE_CPT",
                principalColumn: "CPT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FAV_FLM",
                schema: "public",
                table: "T_J_FAVORI_FAV",
                column: "FLM_ID",
                principalSchema: "public",
                principalTable: "T_E_FILM_FLM",
                principalColumn: "FLM_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAV_CPT",
                schema: "public",
                table: "T_J_FAVORI_FAV");

            migrationBuilder.DropForeignKey(
                name: "FK_FAV_FLM",
                schema: "public",
                table: "T_J_FAVORI_FAV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAV",
                schema: "public",
                table: "T_J_FAVORI_FAV");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_E_FILM_FLM",
                schema: "public",
                table: "T_E_FILM_FLM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_E_COMPTE_CPT",
                schema: "public",
                table: "T_E_COMPTE_CPT");

            migrationBuilder.RenameTable(
                name: "T_J_FAVORI_FAV",
                schema: "public",
                newName: "Favoris",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "T_E_FILM_FLM",
                schema: "public",
                newName: "Film",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "T_E_COMPTE_CPT",
                schema: "public",
                newName: "Comptes",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_T_J_FAVORI_FAV_FLM_ID",
                schema: "public",
                table: "Favoris",
                newName: "IX_Favoris_FLM_ID");

            migrationBuilder.RenameIndex(
                name: "IX_T_E_COMPTE_CPT_CPT_MEL",
                schema: "public",
                table: "Comptes",
                newName: "IX_Comptes_CPT_MEL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "Comptes",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 25, 11, 31, 3, 169, DateTimeKind.Local).AddTicks(9066),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 25, 16, 30, 36, 901, DateTimeKind.Local).AddTicks(4716));

            migrationBuilder.AddPrimaryKey(
                name: "pk_avis",
                schema: "public",
                table: "Favoris",
                columns: new[] { "CPT_ID", "FLM_ID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Film",
                schema: "public",
                table: "Film",
                column: "FLM_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comptes",
                schema: "public",
                table: "Comptes",
                column: "CPT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FAVORI_COMPTE",
                schema: "public",
                table: "Favoris",
                column: "CPT_ID",
                principalSchema: "public",
                principalTable: "Comptes",
                principalColumn: "CPT_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FAVORI_FILM",
                schema: "public",
                table: "Favoris",
                column: "FLM_ID",
                principalSchema: "public",
                principalTable: "Film",
                principalColumn: "FLM_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
