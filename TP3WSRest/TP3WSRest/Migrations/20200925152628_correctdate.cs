using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3WSRest.Migrations
{
    public partial class correctdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FLM_DATEPARUTION",
                schema: "public",
                table: "T_E_FILM_FLM",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "date",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FLM_DATEPARUTION",
                schema: "public",
                table: "T_E_FILM_FLM",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "NOW()");
        }
    }
}
