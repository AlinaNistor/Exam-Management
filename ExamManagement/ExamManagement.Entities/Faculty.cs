using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Faculty :BaseEntity
    {
        public Faculty(string name) : base()
        {
            Name = name;

            Students = new List<User>();
        }

        public string Name { get; set; }
       
        public virtual ICollection<User> Students { get; set; }
    }
}
