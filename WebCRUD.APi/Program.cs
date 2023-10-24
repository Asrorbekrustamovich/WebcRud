
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebCRUD.application.Interfaces;
using WebCRUD.application.mapping;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Iassemblymarker;
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

            builder.Services.AddControllers();//.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //});

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IRepostory<Teacher>,RepositoryForteachers>();
            builder.Services.AddScoped<Iservice<Teacher>,ServiceForTeachers>();
            builder.Services.AddScoped<Iservice<Student>,ServiceForStudent>();
            builder.Services.AddScoped<IRepostory<Student>,RepositoryForStudents>();
            builder.Services.AddDbContext<MyWebapiContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddmappingService();
            builder.Services.AddFluentValidation();
            builder.Services.AddMemoryCache();
            builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
            builder.Services.AddResponseCaching();
            builder.Services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = "localhost:6379";
            }
          );
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseResponseCaching();


            app.MapControllers();

              app.Run();
        }
    }
}