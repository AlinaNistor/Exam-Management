using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Exam : BaseEntity
    {

        public Exam() : base()
        {
        }
        public Exam(Guid facultyId, int yearOfStudy, int mandatory, string name, string headProfessor, string date, int examType, string location, string dateAdded,string details) : base()
        {
            FacultyId = facultyId;
            YearOfStudy = yearOfStudy;
            Mandatory = mandatory;
            Name = name;
            HeadProfessor = headProfessor;
            Date = date;
            ExamType = examType;
            Location = location;
            DateAdded = dateAdded;
            Details = details;

            Comments= new List<Comment>();
            Attendances = new List<Attendance>();
        }
        public Guid FacultyId { get; set; }
        public int YearOfStudy { get; set; }
        public int Mandatory { get; set; } 
        public string Name { get; set; }

        public string HeadProfessor { get; set; }
        public string Date { get; set; }    //DD-MM-YYYY

        public int ExamType { get; set; }    //restanta,normal,restanta1,restanta2 etc
        public string Location { get; set; }    //fizic,online

        public string DateAdded { get; set; }

        public string Details { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
