using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Exam
{
    public sealed class ExamModel
    {
        public ExamModel(Guid id, Guid facultyId, int yearOfStudy, int mandatory, string name, string headProfessor, string date, int examType, string location, string details, string dateAdded, int acceptsCommentaries)
        {
            Id = id;
            FacultyId = facultyId;
            YearOfStudy = yearOfStudy;
            Mandatory = mandatory;
            Name = name;
            HeadProfessor = headProfessor;
            Date = date;
            ExamType = examType;
            Location = location;
            Details = details;
            DateAdded = dateAdded;
            AcceptsCommentaries = acceptsCommentaries;

    }
        public Guid Id { get;  }
        public Guid FacultyId { get; set; }

        [Required(ErrorMessage = "YearOfStudy is required")]
        public int YearOfStudy { get; set; }

        [Required(ErrorMessage = "Mandatory is required")]
        public int Mandatory { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "HeadProfessor is required")]

        public string HeadProfessor { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        [Required(ErrorMessage = "ExamType is required")]

        public int ExamType { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }


        public string Details { get; set; }
        

        public string DateAdded { get;  }

        [Required(ErrorMessage = "AcceptsCommentaries is required")]
        public int AcceptsCommentaries { get; set; }

    }
}
