using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BirlesikOdeme.Database.Repo
{
    public interface IRepository<T>
        where T : class
    {
        T FindById(object EntityId, List<string> includes = null);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null, List<string> includes = null);
        void Insert(T Entity);
        void InsertList(List<T> Entity);
        void Update(T Entity);
        void Delete(object EntityId);
        void Delete(T Entity);
    }
}