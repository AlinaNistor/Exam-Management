using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class HardcodedFaculties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F"), "Automatica si Calculatoare" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.Parse("5FE7C45A-41F9-43F0-91FA-960795F72229"), "Electronică, Telecomunicaţii şi Tehnologia Informaţiei" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.Parse("9609339F-01DE-4057-9AFF-C20BDB664848"), "Construcţii de Maşini şi Management Industrial" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] {  Guid.Parse("EB52EBAC-9320-4B72-BC80-5BCC84D5200B"), "Inginerie Chimică și Protecția Mediului Cristofor Simionescu" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.Parse("333DF729-13F0-4FDC-A0DF-98DA161914A7"), "Arhitectură G.M. Cantacuzino" }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faculty",
                keyColumn: "Name",
                keyValue: "Automatica si Calculatoare");

            migrationBuilder.DeleteData(
               table: "Faculty",
               keyColumn: "Name",
               keyValue: "Arhitectură G.M. Cantacuzino");

            migrationBuilder.DeleteData(
               table: "Faculty",
               keyColumn: "Name",
               keyValue: "Inginerie Chimică și Protecția Mediului Cristofor Simionescu");

            migrationBuilder.DeleteData(
               table: "Faculty",
               keyColumn: "Name",
               keyValue: "Construcţii de Maşini şi Management Industrial");

            migrationBuilder.DeleteData(
               table: "Faculty",
               keyColumn: "Name",
               keyValue: "Electronică, Telecomunicaţii şi Tehnologia Informaţiei");
        }
    }
}
