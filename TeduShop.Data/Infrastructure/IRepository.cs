using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Data.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        // Mark an Entity as new
        void Add(T entity);
        // Mark an Entity as Modified
        void Update(T entity);
        //Mark an Entity to be removed
        void Delete(T entity);
        //Delete multiRecord
        void DeleteMulti(Expression<Func<T, bool>> where);
        // Get an entity by int iD
        T GetSingleByID(int ID);
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IQueryable<T> GetAll(string includes = null);
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        int Count(Expression<Func<T, bool>> where);
        bool CheckContains(Expression<Func<T, bool>> predicate);



            



    }
}
