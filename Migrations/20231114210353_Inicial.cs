using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoWEBMVC3.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cor",
                table: "Tonners");

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Tonners",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "Pedidos",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor",
                table: "Tonners");

            migrationBuilder.AddColumn<string>(
                name: "cor",
                table: "Tonners",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<float>(
                name: "valor",
                table: "Pedidos",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
