using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Domain.Intarfaces
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public bool Remove(T entity);

        public IEnumerable<T> GetAll();

        public T? FindById(int id);

        public bool UpDate(T entity);


        //ToDO DBContext
        public void Save();
        public  Task SaveAsync();  


    }
}
