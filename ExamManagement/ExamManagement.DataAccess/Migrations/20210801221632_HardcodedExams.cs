using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class HardcodedExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   1,
                   1, //conventia e 0 Not mandatory 1 Mandatory
               "Metode Numerice",
               "Doamna Profesor",
               "25/06/2021",
               0,   //0 essay 1 oral  2 practical
               "Facultate",
               "02/06/2021",
               "Se va da examenul in salile AC0-2 si AC0-1",
               Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
               }
               );

            migrationBuilder.InsertData(
                   table: "Exams",
                   columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
                   values: new object[] { Guid.NewGuid(),
                   3,
                   1, //conventia e 0 Not mandatory 1 Mandatory
               "Sisteme Distribuite",
               "Doamnul Profesor 2",
               "15/06/2021",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "01/06/2021",
               "In salile AC2-12 si AC2-13",
               Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                   }
                   );
            
            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   2,
                   1, //conventia e 0 Not mandatory 1 Mandatory
               "Paoo ",
               "Doamnul Profesor 3",
               "25/06/2021",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "02/06/2021",
               "C0-1 -> C0-6",
               Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
               }
               );

            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   1,
                   0, //conventia e 0 Not mandatory 1 Mandatory
               "Alcaline Cred ",
               "Doamna Profesor 3",
               "20/06/2021",
               1,   //0 essay 1 oral  2 practical
               "Facultate",
               "03/06/2021",
               "Va astept la facultate",
               Guid.Parse("EB52EBAC-9320-4B72-BC80-5BCC84D5200B")
               }
               );

            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   1,
                   1, //conventia e 0 Not mandatory 1 Mandatory
               "Examen la telecomunicatii ",
               "Doamna Profesor",
               "25/06/2021",
               1,   //0 essay 1 oral  2 practical
               "Online",
               "04/06/2021",
               "Se da examenul online",
               Guid.Parse("5FE7C45A-41F9-43F0-91FA-960795F72229")
               }
               );

            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   1,
                   1, //conventia e 0 Not mandatory 1 Mandatory
               "Materiale de constructie ",
               "Doamna Profesor F",
               "20/05/2021",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "02/06/2021",
               "Se va da examenul in salile AC0-2 si AC0-1",
               Guid.Parse("333DF729-13F0-4FDC-A0DF-98DA161914A7")
               }
               );


            migrationBuilder.InsertData(
               table: "Exams",
               columns: new[] { "Id"
      ,"YearOfStudy"
      ,"Mandatory"
      ,"Name"
      ,"HeadProfessor"
      ,"Date"
      ,"ExamType"
      ,"Location"
      ,"DateAdded"
      ,"Details"
      ,"FacultyId" },
               values: new object[] { Guid.NewGuid(),
                   1,
                   0, //conventia e 0 Not mandatory 1 Mandatory
               "Engleza ",
               "Doamna Profesor",
               "25/06/2021",
               1,   //0 essay 1 oral  2 practical
               "Online",
               "02/06/2021",
               "Examenul se va da online oral dupa ordinea pusa pe Moodle",
               Guid.Parse("9609339F-01DE-4057-9AFF-C20BDB664848")
               }
               );


           



        }

        

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
           table: "Faculty",
           keyColumn: "Name",
           keyValue: "Metode Numerice");

            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Engleza");

            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Materiale de constructie");
            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Materiale de constructie");
            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Examen la telecomunicatii");
            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Paoo");
            migrationBuilder.DeleteData(
          table: "Faculty",
          keyColumn: "Name",
          keyValue: "Sisteme Distribuite");

            
        }
    }
}
