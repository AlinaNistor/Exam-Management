using Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.Persistence.Mappings
{
    internal abstract class NotificationMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                                        .Property(s => s.Id)
                                        .HasColumnName("Id")
                                        .IsRequired();
            modelBuilder.Entity<Notification>()
                .Property(s => s.NotifyNoOfDaysPrior)
                .HasColumnName("NotifyNoOfDaysPrior");

            modelBuilder.Entity<Notification>()
                .Property(s => s.DateAdded)
                .HasColumnName("DateAdded")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Exam>()
                .HasOne(s => s.Notification)
                .WithOne(g => g.Exam)
                .HasForeignKey("ExamId");
           }
    }
}
