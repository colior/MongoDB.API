using System.Linq;
using System;

namespace Cyclist.Services
{
    public interface IService<T>
    {
        void Insert(T student);
        T Get(String i);
        IQueryable<T> GetAll();
        void Delete(String id);
        void Update(T student);
    }
}
