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
            if (entity != null)
            {
                _context.Students.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public bool delete(int deleteid)
        {
            var deletedobject = _context.Students.Find(deleteid);
            if (deletedobject != null)
            {
                _context.Students.Remove(deletedobject);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Student> Getall()
        {
            var getall = _context.Students;
            if (getall != null)
            {
                return getall;
            }
            return null;
        }

        public Student getbyid(int id)
        {
            var getbyid = _context.Students.Find(id);
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
            var updatedobject = _context.Students.Find(entity.Id);
            if (updatedobject != null)
            {
                updatedobject.Teachers = entity.Teachers;
                updatedobject.Fullname = entity.Fullname;
                _context.Students.Update(updatedobject);
                return true;
            }
            return false;
        }
    }
}
