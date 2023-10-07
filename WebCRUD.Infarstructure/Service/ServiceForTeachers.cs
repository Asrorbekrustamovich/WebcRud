using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;

namespace WebCRUD.Infarstructure.Service
{
    public class ServiceForTeachers:Iservice<Teacher>
    {
        private readonly IRepostory<Teacher> _repostory;
        public ServiceForTeachers(IRepostory<Teacher>repostory)
        {
            _repostory = repostory;
        }

        public Teacher Create(Teacher entity)
        {
           if(_repostory.create(entity)!=null)
            {
                return entity;
            }
           else
            {
                return null;
            }
        }

        public string Delete(int deletedid)
        {
            if(_repostory.delete(deletedid)==true)
            {
                return "object is deleted";
            }
            return "object is not deleted";
        }

        public IEnumerable<Teacher> Getall()
        {
            return _repostory.Getall();
        }

        public Teacher GetById(int id)
        {
           return _repostory.getbyid(id);
        }

        public string Update(Teacher entity)
        {
           if(_repostory.update(entity))
            {
                return "updated";
            }
            return "error";
        }
    }
}
