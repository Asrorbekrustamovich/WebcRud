using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;
using WebCRUD.Domain.Models;
using WebCRUD.Infarstructure.Mydbcontext;

namespace WebCRUD.Infarstructure.Repository
{
    public class RepositoryForStudents : IRepostory<Student>
    {
        private readonly Mydbcontext.MyWebapiContext _context;

        public RepositoryForStudents(MyWebapiContext myWebapiContext)
        {
            _context = myWebapiContext;
        }

        public Student create(Student entity)
        {
                _context.Attach(entity);
                _context.SaveChanges();
                return entity;
        }

        public bool delete(int deleteid)
        {
            var deletedobject = _context.Students.Find(deleteid);
            if (deletedobject != null)
            {
                _context.Students.Remove(deletedobject);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Student> Getall()
        {
            var getall = _context.Students.Include(x=>x.Teachers);
            if (getall != null)
            {
                return getall;
            }
            return null;
        }

        public Student getbyid(int id)
        {
            Student getbyid = _context.Students.Include(x => x.Teachers).First(x=>x.Id==id);
            if (getbyid != null)
            {
                return getbyid;
            }
            else
            {
                return null;
            }
        }

        public bool update(Student entity)
        {
                Student newstudent=new Student();
                newstudent.Id = entity.Id;

                newstudent.Email = entity.Email;
                newstudent.Password = entity.Password;
                newstudent.Fullname = entity.Fullname;

                _context.Students.Update(newstudent);
                _context.SaveChanges();
                return true;
        }
    }
}
