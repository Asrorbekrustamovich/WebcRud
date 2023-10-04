using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCRUD.application.Interfaces
{
    public interface Iservice<T> where T : class
    {
        public T Create(T entity);
        public string Update(T entity);
        public string Delete(int deletedid);
        public IEnumerable<T> Getall();
        public T GetById(int id);
    }
}
