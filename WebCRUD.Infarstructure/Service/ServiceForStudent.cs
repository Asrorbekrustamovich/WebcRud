using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Entities;

namespace WebCRUD.Infarstructure.Service
{
    public class ServiceForStudent : Iservice<Student>
    {
        private readonly IRepostory<Student> _repostory;
        public ServiceForStudent(IRepostory<Student> repostory)
        {
            _repostory = repostory;
        }

        public Student Create(Student entity)
        {
            if (_repostory.create(entity) != null)
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
            if (_repostory.delete(deletedid) == true)
            {
                return "object is deleted";
            }
            return "object is not deleted";
        }

        public IEnumerable<Student> Getall()
        {
            return _repostory.Getall();
        }

        public Student GetById(int id)
        {
            return _repostory.getbyid(id);
        }

        public string Update(Student entity)
        {
            if (_repostory.update(entity))
            {
                return "updated";
            }
            return "error";
        }
    }
}
