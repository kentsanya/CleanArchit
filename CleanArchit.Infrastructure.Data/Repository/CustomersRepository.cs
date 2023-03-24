using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Infrastructure.Data.Repository
{
    internal class CustomersRepository : IRepository<Customer>
    {
        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool UpDate(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
