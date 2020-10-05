using Microsoft.EntityFrameworkCore.Migrations;

namespace TP3WSRest.Migrations
{
    public partial class updatepasswordlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPT_PWD",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPT_PWD",
                schema: "public",
                table: "T_E_COMPTE_CPT",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
