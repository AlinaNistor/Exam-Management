using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User:BaseEntity
    {

        public User(string lastName, string firstName, string email, string password, int role, Guid facultyId) : base()
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;
            Password = password;
            Role = role;
            FacultyId=facultyId;
            

            Comments = new List<Comment>();
            Attendances = new List<Attendance>();
            
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Guid FacultyId { get; set; }
    


        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual Faculty Faculty { get; set; }

    }
}
