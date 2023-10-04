using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.application.Interfaces
{
    public interface IRepostory<T> where T : class
    {
        public T create(T entity);
        public bool update(T entity);
        public bool delete(int deleteid);
        public IEnumerable<T> Getall();
        public T getbyid(int id);
    }
}
