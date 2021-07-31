using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class QuestionMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                           .Property(s => s.Id)
                           .HasColumnName("Id")
                           .IsRequired();

            

            modelBuilder.Entity<Question>()
                           .Property(s => s.Text)
                           .HasColumnName("Text")
                           .HasMaxLength(255)
                           .IsRequired();

            modelBuilder.Entity<Question>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Question>()
                .HasMany(s => s.Answers)
                .WithOne(g => g.Question)
                .HasForeignKey(s => s.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
         
    }
    }
}
