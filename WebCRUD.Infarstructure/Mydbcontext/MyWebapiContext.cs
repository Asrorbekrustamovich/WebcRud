using Microsoft.EntityFrameworkCore;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;

namespace WebCRUD.Infarstructure.Mydbcontext
{
    public  class MyWebapiContext:DbContext
    {
        public MyWebapiContext()
        {
            
        }
        public MyWebapiContext(DbContextOptions<MyWebapiContext> options) : base(options)
        {

        }
        public DbSet<Teacher>Teachers  { get; set; }
        public DbSet<Student>Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=::1;Port=5432;Database=Hello;user id=postgres;password=123456");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
