
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;
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
            builder.Services.AddSingleton<IRepostory<Teacher>,RepositoryForteachers>();
            builder.Services.AddSingleton<Iservice<Teacher>,ServiceForTeachers>();


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