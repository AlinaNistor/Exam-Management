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
        public Exam(string faculty, int yearOfStudy, int mandatory, string name, string headProfessor, string date, int examType, string location, string dateAdded) : base()
        {
            Faculty = faculty;
            YearOfStudy = yearOfStudy;
            Mandatory = mandatory;
            Name = name;
            HeadProfessor = headProfessor;
            Date = date;
            ExamType = examType;
            Location = location;
            DateAdded = dateAdded;

            Questions = new List<Question>();
            Attendances = new List<Attendance>();
        }
        public string Faculty { get; set; }
        public int YearOfStudy { get; set; }
        public int Mandatory { get; set; } 
        public string Name { get; set; }

        public string HeadProfessor { get; set; }
        public string Date { get; set; }    //DD-MM-YYYY

        public int ExamType { get; set; }    //restanta,normal,restanta1,restanta2 etc
        public string Location { get; set; }    //fizic,online

        public string DateAdded { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}
