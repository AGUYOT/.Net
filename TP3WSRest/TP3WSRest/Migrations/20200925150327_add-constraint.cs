using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3WSRest.Migrations
{
    public partial class addconstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 9, 25, 16, 30, 36, 901, DateTimeKind.Local).AddTicks(4716));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CPT_DATECREATION",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 25, 16, 30, 36, 901, DateTimeKind.Local).AddTicks(4716),
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "NOW()");
        }
    }
}
