using Microsoft.EntityFrameworkCore;
using System;
using Entities;
using DataAccess.Mappings;
using ExamManagement.Persistence.Mappings;

namespace DataAccess
{
    public class ExamContext:DbContext
    {
        public ExamContext()
        {

        }
        public ExamContext(DbContextOptions<ExamContext> options)
        {
            Database.Migrate();


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Modify connection string
            string connectionString = @"Data source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ExamManager;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            CommentMapping.Map(modelBuilder);
            AttendanceMapping.Map(modelBuilder);
            ExamMapping.Map(modelBuilder);
            
            UserMapping.Map(modelBuilder);
            FacultyMapping.Map(modelBuilder);
            NotificationMapping.Map(modelBuilder);
            
        }

        //entities
       
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Faculty> Faculty { get; set; }

        //void Includes() {
        //    Users.Include<Exam>().ToListAsync();

        //}

    }




}

