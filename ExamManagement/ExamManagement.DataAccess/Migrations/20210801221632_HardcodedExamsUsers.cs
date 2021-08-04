using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAccess.Migrations
{
    public partial class HardcodedExamsUsers : Migration
    {


        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Users
            //Adding students
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
            "LastName",
            "FirstName",
            "Email" ,
            "Password" ,    
            "Role" ,        //0 student 1 prof
            "FacultyId"
        },
                values: new object[]{
                    Guid.Parse("09d55ac9-894b-4443-98f6-d6519b0b7fe5"),
            "Fraiha",
            "Holt",
            "Fraiha@email.com" ,
            "IbE4jkIaKSXq+PxHg1M9EA==.59K5QUpGFikh+rbjs7y91zYxdi7OKFprgpo4TZ19cN0=" ,
            0,
            Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
            "LastName",
            "FirstName",
            "Email" ,
            "Password" ,
            "Role" ,        //0 student 1 prof
            "FacultyId"
        },
                values: new object[]{
                    Guid.Parse("09d55ac9-894b-4443-98f6-d6519b0b7fe6"),
            "Orson",
            "Nicholson",
            "Orson@email.com" ,
            "20T9uonr+mSgbmSmyAYCvQ==.ZQKk2yWHznYKi0nksRE8DGUF+IB5AV9uf6MOYcRJM+4=" ,
            0,
            Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id",
            "LastName",
            "FirstName",
            "Email" ,
            "Password" ,
            "Role" ,        //0 student 1 prof
            "FacultyId"
        },
                values: new object[]{
                    Guid.Parse("09d55ac9-894b-4443-98f6-d6519b0b7fe7"),
            "Mollie",
            "Wagstaff",
            "MollieProf@email.com" ,
            "laYXGMfsghvyyK/bCAdIzQ==.iCScQvSWUg442LPiTKyVBJ0D7R559/mPVgerpHUimKI=" ,
            1,
            Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                });
            migrationBuilder.InsertData(
                    table: "Users",
                    columns: new[]
                    {
                    "Id",
            "LastName",
            "FirstName",
            "Email" ,
            "Password" ,
            "Role" ,        //0 student 1 prof
            "FacultyId"
            },
                    values: new object[]{
                    Guid.Parse("09d55ac9-894b-4443-98f6-d6519b0b7fe8"),
            "Donald",
            "Moore",
            "DonaldProf1@email.com" ,
            "IoAU2Aoat7UD19s794jpTA==.P/zNvlIMf3qUUuFjK2xEULYId7S86bmaZVbNnMPhWvY=" ,
            1,
            Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                    });
            migrationBuilder.InsertData(
                    table: "Users",
                    columns: new[]
                    {
                    "Id",
            "LastName",
            "FirstName",
            "Email" ,
            "Password" ,
            "Role" ,        //0 student 1 prof
            "FacultyId"
            },
                    values: new object[]{
                    Guid.Parse("09d55ac9-894b-4443-98f6-d6519b0b7fe9"),
            "Honey",
            "Rivera",
            "HoneyProf2@email.com" ,
            "XBPeaBc/jBG5XsHqlkVdHQ==.8c8RbeMu6ucFrDot2ScfabR8rl5MVpo4ZtYol4cdoJo=" ,
            1,
            Guid.Parse("B3FA4F8A-23BC-4839-898C-438608A0328F")
                    });

            //Exams
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe9",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe8",
               "01-Sep-21",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "04-Aug-21",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe9",
               "27-Aug-21",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "03-Aug-21",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe7",
               "24-Aug-21",
               1,   //0 essay 1 oral  2 practical
               "Facultate",
               "01-Aug-21",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe9",
               "03-Sep-21",
               1,   //0 essay 1 oral  2 practical
               "Online",
               "01-Aug-21",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe8",
               "23-Aug-21",
               2,   //0 essay 1 oral  2 practical
               "Facultate",
               "04-Aug-21",
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
               "09d55ac9-894b-4443-98f6-d6519b0b7fe7",
               "03-Sep-21",
               1,   //0 essay 1 oral  2 practical
               "Online",
               "02-Aug-21",
               "Examenul se va da online oral dupa ordinea pusa pe Moodle",
               Guid.Parse("9609339F-01DE-4057-9AFF-C20BDB664848")
               }
               );


           



        }

        

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
           table: "User",
           keyColumn: "FirstName",
           keyValue: "Student");
            migrationBuilder.DeleteData(
           table: "User",
           keyColumn: "FirstName",
           keyValue: "Student2");
            migrationBuilder.DeleteData(
           table: "User",
           keyColumn: "FirstName",
           keyValue: "Admin");




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
