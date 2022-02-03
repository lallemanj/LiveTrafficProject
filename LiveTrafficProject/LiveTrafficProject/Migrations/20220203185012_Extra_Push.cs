using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveTrafficProject.Migrations
{
    public partial class Extra_Push : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Properties_propertiesId",
                table: "Incident");

            migrationBuilder.DropIndex(
                name: "IX_Incident_propertiesId",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "Geometry");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "propertiesId1",
                table: "Incident",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PropertiesId",
                table: "Event",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incident_propertiesId1",
                table: "Incident",
                column: "propertiesId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Properties_propertiesId1",
                table: "Incident",
                column: "propertiesId1",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Properties_propertiesId1",
                table: "Incident");

            migrationBuilder.DropIndex(
                name: "IX_Incident_propertiesId1",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "propertiesId1",
                table: "Incident");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Properties",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Coordinates",
                table: "Geometry",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertiesId",
                table: "Event",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incident_propertiesId",
                table: "Incident",
                column: "propertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Properties_propertiesId",
                table: "Incident",
                column: "propertiesId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
