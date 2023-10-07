using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;
using WebCRUD.Infarstructure.Mydbcontext;

namespace WebCRUD.Infarstructure.Repository
{
    public class RepositoryForteachers : IRepostory<Teacher>
    {private readonly Mydbcontext.MyWebapiContext _context;

        public RepositoryForteachers(MyWebapiContext myWebapiContext)
        {
            _context = myWebapiContext;
        }

        public Teacher create(Teacher entity)
        {
            if(entity != null)
            {
                _context.Teachers.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            return null;
        }

        public bool delete(int deleteid)
        {
            var deletedobject = _context.Teachers.Find(deleteid);
            if(deletedobject != null)
            {
                _context.Teachers.Remove(deletedobject);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Teacher> Getall()
        {
            var getall = _context.Teachers;
            if(getall != null)
            {
                return getall;
            }
            return null;
        }

        public Teacher getbyid(int id)
        {
            var getbyid= _context.Teachers.Find(id);
            if (getbyid != null)
            {
                return getbyid;
            }
            else
            {
                return null;
            }
        }

        public bool update(Teacher entity)
        {
            var updatedobject = _context.Teachers.Find(entity.Id);
            if(updatedobject != null)
            {
                Teacher teacher = new Teacher()
                {
                    Name = entity.Name,
                    Email= entity.Email,
                    Password= entity.Password,
                };
                _context.Teachers.Update(teacher);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
