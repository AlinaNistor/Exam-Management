using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class AttendanceMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                            .Property(s => s.Id)
                            .HasColumnName("Id")
                            .IsRequired();
            //modelBuilder.Entity<Attendance>()
            //                .Property(s => s.ExamId)
            //                .HasColumnName("ExamId")
            //                ;

            //modelBuilder.Entity<Attendance>()
            //                .Property(s => s.StudentId)
            //                .HasColumnName("StudentId")
            //                .IsRequired();

            modelBuilder.Entity<Attendance>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
