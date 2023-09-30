using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;
using WebCRUD.Infarstructure.Mydbcontext;

namespace WebCRUD.Infarstructure.Repository
{
    public class Repository : IRepostory<User>
    {private readonly Mydbcontext.MyWebapiContext _context;

        public Repository()
        {
            _context = new MyWebapiContext();
        }

        public bool create(User entity)
        {
           if(entity != null) 
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return true;
            }
           return false;    
        }

        public bool delete(int deleteid)
        {
            var deletedobject = _context.Users.FirstOrDefault(x=>x.Id==deleteid);
            if(deletedobject != null)
            {
                _context.Users.Remove(deletedobject);
                _context.SaveChanges();
                return true;
            }
            return false;   
        }

        public IEnumerable<User> Getall()
        {
            var getalluser = _context.Users;
            if(getalluser != null)
            {
                return getalluser;
            }
            return Enumerable.Empty<User>();
        }

        public User getbyid(int id)
        {
           var getbyiduser= _context.Users.FirstOrDefault(x=>x.Id== id);    
            if(getbyiduser != null)
            {
                return getbyiduser;
            }
            return null;
        }

        public bool update(User entity)
        {
           var Updatedobject= _context.Users.FirstOrDefault(x=>x.Id==entity.Id);
           if(Updatedobject != null)
            {
               Updatedobject.Email = entity.Email;
                Updatedobject.Name= entity.Name;
                Updatedobject.Password= entity.Password;
                _context.Users.Update(Updatedobject);
                _context.SaveChanges();
                return true;

            }
            return false;
        }
    }
}
