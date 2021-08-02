using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class ExamMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                            .Property(s => s.Id)
                            .HasColumnName("Id")
                            .IsRequired();

            modelBuilder.Entity<Exam>()
                            .Property(s => s.YearOfStudy)
                            .HasColumnName("YearOfStudy")
                            .IsRequired();

            modelBuilder.Entity<Exam>()
                            .Property(s => s.Mandatory)
                            .HasColumnName("Mandatory")
                            .IsRequired();

            modelBuilder.Entity<Exam>()
                            .Property(s => s.Name)
                            .HasColumnName("Name")
                            .HasMaxLength(30)
                            .IsRequired();

            modelBuilder.Entity<Exam>()
                            .Property(s => s.HeadProfessor)
                            .HasColumnName("HeadProfessor")
                            .HasMaxLength(30)
                            .IsRequired();
            modelBuilder.Entity<Exam>()
                            .Property(s => s.Details)
                            .HasColumnName("Details")
                            .HasMaxLength(500);

            modelBuilder.Entity<Exam>()
                            .Property(s => s.Date)
                            .HasColumnName("Date");


            modelBuilder.Entity<Exam>()
                            .Property(s => s.ExamType)
                            .HasColumnName("ExamType");
                            

            modelBuilder.Entity<Exam>()
                            .Property(s => s.Location)
                            .HasColumnName("Location")
                            .HasMaxLength(50);
           
            modelBuilder.Entity<Exam>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(20)
                .IsRequired();


            modelBuilder.Entity<Exam>()
                .HasMany(s => s.Comments)
                .WithOne(g => g.Exam)
                .HasForeignKey(s => s.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exam>()
               .HasMany(s => s.Attendances)
               .WithOne(g => g.Exam)
               .HasForeignKey(s => s.ExamId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Exam>()
                .HasOne(s => s.Faculty)
                .WithMany(g => g.Exams)
                .HasForeignKey(s => s.FacultyId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
