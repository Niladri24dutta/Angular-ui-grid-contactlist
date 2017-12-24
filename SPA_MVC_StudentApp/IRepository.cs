using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPA_MVC_StudentApp
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> Search(string query);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T SeachById(int id);

        IEnumerable<T> ShowAll();

    }
}
