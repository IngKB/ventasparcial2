using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Codigo", "Costo", "Discriminator", "Nombre", "Precio" },
                values: new object[] { 1, 10, "001", 500m, "ProductoSimple", "Pan", 0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Codigo", "Costo", "Discriminator", "Nombre", "Precio" },
                values: new object[] { 2, 10, "002", 1000m, "ProductoSimple", "Salchicha", 0m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Cantidad", "Codigo", "Costo", "Discriminator", "Nombre", "Precio" },
                values: new object[] { 3, 10, "003", 1000m, "ProductoSimple", "Cocacola", 3000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
