using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Faculty
{
    public sealed class FacultyModel
    {
        public FacultyModel(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
