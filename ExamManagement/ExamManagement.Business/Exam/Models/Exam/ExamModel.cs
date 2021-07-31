using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Exam
{
    public sealed class ExamModel
    {
        public ExamModel(Guid id, string faculty, int yearOfStudy, int mandatory, string name, string headProfessor, string date, int examType, string location)
        {
            Id = id;
            Faculty = faculty;
            YearOfStudy = yearOfStudy;
            Mandatory = mandatory;
            Name = name;
            HeadProfessor = headProfessor;
            Date = date;
            ExamType = examType;
            Location = location;

        }
        public Guid Id { get;  }
        public string Faculty { get; set; }
        public int YearOfStudy { get; set; }
        public int Mandatory { get; set; } 
        public string Name { get; set; }

        public string HeadProfessor { get; set; }
        public string Date { get; set; }    //DD-MM-YYYY

        public int ExamType { get; set; }    //restanta,normal,restanta1,restanta2 etc
        public string Location { get; set; }    //fizic,online

       // public string DateAdded { get; set; }

    }
}
