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

            Database.BeginTransaction();
            Database.ExecuteSqlRaw("INSERT into Faculty (Id,Name) values ('58369ae7-b517-4c5a-96a3-6b098e2f8581','Arhitectură G.M. Cantacuzino') ");
            Database.CommitTransaction();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Modify connection string
            string connectionString = @"Data source=localhost\SQLEXPRESS;Initial Catalog=ExamManager;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            AnswerMapping.Map(modelBuilder);
            AttendanceMapping.Map(modelBuilder);
            ExamMapping.Map(modelBuilder);
            QuestionMapping.Map(modelBuilder);
            UserMapping.Map(modelBuilder);
            FacultyMapping.Map(modelBuilder);
            
        }

        //entities
       
        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Faculty> Faculty { get; set; }

        //void Includes() {
        //    Users.Include<Exam>().ToListAsync();

        //}

    }




}

