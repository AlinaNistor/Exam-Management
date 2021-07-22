using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class UserMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<User>()
               .Property(s => s.FirstName)
               .HasColumnName("FirstName")
               .HasMaxLength(50)
               .IsRequired();
            modelBuilder.Entity<User>()
                  .Property(s => s.Email)
                  .HasColumnName("Email")
                  .HasMaxLength(50)
                  .IsRequired();
            modelBuilder.Entity<User>()
                      .Property(s => s.Password)
                      .HasColumnName("Password")
                      .HasMaxLength(250)
                      .IsRequired();
            modelBuilder.Entity<User>()
                  .Property(s => s.Role)
                  .HasColumnName("Role")
                  .IsRequired();
            modelBuilder.Entity<User>()
                      .Property(s => s.YearOfStudy)
                      .HasColumnName("YearOfStudy");
            modelBuilder.Entity<User>()
                  .Property(s => s.Tax)
                  .HasColumnName("Tax");


            modelBuilder.Entity<User>()
                .HasMany(s => s.Attendances)
                .WithOne(g => g.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Questions)
                .WithOne(g => g.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(s => s.Answers)
                .WithOne(g => g.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);
    }
    }
}
