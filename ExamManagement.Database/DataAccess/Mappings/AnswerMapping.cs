using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class AnswerMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                            .Property(s => s.Id)
                            .HasColumnName("Id")
                            .IsRequired();

            //modelBuilder.Entity<Answer>()
            //                .Property(s => s.QuestionId)
            //                .HasColumnName("QuestionId")
            //                ;
            //modelBuilder.Entity<Answer>()
            //                .Property(s => s.UserId)
            //                .HasColumnName("UserId")
            //                .IsRequired();
            modelBuilder.Entity<Answer>()
                            .Property(s => s.Text)
                            .HasColumnName("Text")
                            .HasMaxLength(255)
                            .IsRequired();
            modelBuilder.Entity<Answer>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(20)
                .IsRequired();


        }
    }
}
