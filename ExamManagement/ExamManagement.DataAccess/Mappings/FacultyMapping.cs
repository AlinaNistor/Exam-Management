using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ExamManagement.Persistence.Mappings
{
    internal abstract class FacultyMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Faculty>()
                            .Property(s => s.Id)
                            .HasColumnName("Id")
                            .IsRequired();

            modelBuilder.Entity<Entities.Faculty>()
                .HasMany(s => s.Students)
                .WithOne(g => g.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            


        }
    }
}
