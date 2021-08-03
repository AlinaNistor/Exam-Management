using DataAccess;
using Entities;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamManagement.Persistence;
using ExamManagement.Business.Exam.Services;
using ExamManagement.Business;
using ExamManagement.Business.Exam.Services.Auth;
using ExamManagement.Persistence.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ExamManagement.Business.Exam.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using ExamManagement.Persistence.Exams;
using ExamManagement.Business.Exam.Services.Exam;
using Microsoft.AspNetCore.Http;
using ExamManagement.Persistence.Faculty;
using ExamManagement.Business.Exam.Services.Faculty;
using ExamManagement.Persistence.Repositories.Attendances;
using ExamManagement.Business.Exam.Services.Attendance;
using ExamManagement.Persistence.Repositories.Comments;
using ExamManagement.Business.Exam.Services.Comment;
using ExamManagement.Business.Exam.Services.Admin;

namespace ExamManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAuthentication(services);
            services.AddCors();
            services.AddControllers();
          
            services.AddDbContext<ExamContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("ExamConnection"));
            });
           
            services.AddSwaggerGen();

            services.AddAutoMapper(config => {
                config.AddProfile<UsersMappingProfile>();
                config.AddProfile<ExamsMappingProfile>();
                config.AddProfile<FacultyMappingProfile>();
                config.AddProfile<AttendancesMappingProfile>();
                config.AddProfile<CommentMappingProfile>();
            
            });
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IExamsRepository, ExamsRepository>()
                .AddScoped<IExamService, ExamService>()
                .AddScoped<IFacultyRepository, FacultyRepository>()
                .AddScoped<IFacultyService, FacultyService>()
                .AddScoped<IAttendancesRepository, AttendanceRepository>()
                .AddScoped<IAttendanceService, AttendanceService>()
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IAdminService, AdminService>();



            services
                .AddMvc();
            services.AddHttpContextAccessor();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Exam Management V1");
            });

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<ExamContext>();
            dbContext.Database.EnsureCreated();

            
        }
        private void AddAuthentication(IServiceCollection services)
        {
            var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience
                        
                    };
                });
        }
    }
}
