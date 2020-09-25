using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TP3WSRest.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "Comptes",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CPT_NOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_PRENOM = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_TELPORTABLE = table.Column<string>(type: "char(10)", nullable: true),
                    CPT_MEL = table.Column<string>(maxLength: 100, nullable: false),
                    CPT_PWD = table.Column<string>(maxLength: 64, nullable: true),
                    CPT_RUE = table.Column<string>(maxLength: 200, nullable: false),
                    CPT_CP = table.Column<string>(type: "char(5)", nullable: false),
                    CPT_VILLE = table.Column<string>(maxLength: 50, nullable: false),
                    CPT_PAYS = table.Column<string>(maxLength: 50, nullable: false, defaultValue: "France"),
                    CPT_LATITUDE = table.Column<float>(nullable: true),
                    CPT_LONGITUDE = table.Column<float>(nullable: true),
                    CPT_DATECREATION = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 25, 11, 31, 3, 169, DateTimeKind.Local).AddTicks(9066))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.CPT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                schema: "public",
                columns: table => new
                {
                    FLM_ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FLM_TITRE = table.Column<string>(maxLength: 100, nullable: false),
                    FLM_SYNOPSIS = table.Column<string>(maxLength: 500, nullable: true),
                    FLM_DATEPARUTION = table.Column<DateTime>(nullable: false),
                    FLM_DUREE = table.Column<decimal>(nullable: false),
                    FLM_GENRE = table.Column<string>(maxLength: 30, nullable: false),
                    FLM_URLPHOTO = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FLM_ID);
                });

            migrationBuilder.CreateTable(
                name: "Favoris",
                schema: "public",
                columns: table => new
                {
                    CPT_ID = table.Column<int>(nullable: false),
                    FLM_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_avis", x => new { x.CPT_ID, x.FLM_ID });
                    table.ForeignKey(
                        name: "FK_FAVORI_COMPTE",
                        column: x => x.CPT_ID,
                        principalSchema: "public",
                        principalTable: "Comptes",
                        principalColumn: "CPT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAVORI_FILM",
                        column: x => x.FLM_ID,
                        principalSchema: "public",
                        principalTable: "Film",
                        principalColumn: "FLM_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_CPT_MEL",
                schema: "public",
                table: "Comptes",
                column: "CPT_MEL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_FLM_ID",
                schema: "public",
                table: "Favoris",
                column: "FLM_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoris",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Comptes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Film",
                schema: "public");
        }
    }
}
