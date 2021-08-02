using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Mappings
{
    internal abstract class CommentMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                            .Property(s => s.Id)
                            .HasColumnName("Id")
                            .IsRequired();

            modelBuilder.Entity<Comment>()
                .Property(s => s.ParentId)
                .HasColumnName("ParentId");


            modelBuilder.Entity<Comment>()
                            .Property(s => s.Text)
                            .HasColumnName("Text")
                            .HasMaxLength(255)
                            .IsRequired();


            modelBuilder.Entity<Comment>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(20)
                .IsRequired();


        }
    }
}
