using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCRUD.application.Interfaces;
using WebCRUD.Domain.Models;
using WebCRUD.Infarstructure.Repository;

namespace WebCRUD.Infarstructure.Service
{
    public class Service:Iservice<User>
    {
        private readonly IRepostory<User> _repostory;
        public Service()
        {
            _repostory = new Repository.Repository();
        }

        public string Create(User entity)
        {
            if(_repostory.create(entity)) 
            {
                return "object is Created";
            }
            return "object is not created";
        }

        public string Delete(int deletedid)
        {
            if(_repostory.delete(deletedid))
            {
                return "object is deleted";
            }
            return "object is not deleted";
        }

        public IEnumerable<User> Getall()
        {
            return _repostory.Getall();
        }

        public User GetById(int id)
        {
            return _repostory.getbyid(id);
        }

        public string Update(User entity)
        {
            if(_repostory.update(entity))
            {
                return "object is updated";
            }
            return "object is not updated";
        }
    }
}
