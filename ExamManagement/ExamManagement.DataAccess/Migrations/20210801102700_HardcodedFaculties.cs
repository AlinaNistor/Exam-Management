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
                values: new object[] { Guid.NewGuid(), "Automatica si Calculatoare" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.NewGuid(), "Electronică, Telecomunicaţii şi Tehnologia Informaţiei" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.NewGuid(), "Construcţii de Maşini şi Management Industrial" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.NewGuid(), "Inginerie Chimică și Protecția Mediului Cristofor Simionescu" }
                );

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "Id", "Name" },
                values: new object[] { Guid.NewGuid(), "Arhitectură G.M. Cantacuzino" }
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
