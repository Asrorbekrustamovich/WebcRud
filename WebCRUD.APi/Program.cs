
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;
using WebCRUD.Infarstructure.Mydbcontext;
using WebCRUD.Infarstructure.Repository;
using WebCRUD.Infarstructure.Service;

namespace WebCRUD.APi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepostory<Teacher>,RepositoryForteachers>();
            builder.Services.AddScoped<Iservice<Teacher>,ServiceForTeachers>();
            builder.Services.AddScoped<Iservice<Student>,ServiceForStudent>();
            builder.Services.AddScoped<IRepostory<Student>,RepositoryForStudents>();
            builder.Services.AddDbContext<MyWebapiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}