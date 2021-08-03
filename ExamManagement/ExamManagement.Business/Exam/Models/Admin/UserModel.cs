using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Business.Exam.Models.Admin
{
    public class UserModel
    {

        public UserModel(Guid id, string lastName, string firstName, string email, string password, int role, Guid facultyId)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
            Role = role;
            FacultyId = facultyId;

        }
        public Guid Id { get;}
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Guid FacultyId { get; set; }
    }
}
