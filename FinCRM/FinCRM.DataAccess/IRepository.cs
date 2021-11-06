using FinCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace FinCRM.DataAccess
{
    //<T> oznacza typ generyczny.
    // T wykorzystuje EntityBase, czyli wszystkie encje z naszej bazy danych
    public interface IRepository<T> where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);  
        void Delete(int id);  

    }
}
