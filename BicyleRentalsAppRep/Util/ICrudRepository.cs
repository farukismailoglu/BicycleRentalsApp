using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BicyleRentalsApp.Util
{
    interface ICrudRepository<T, ID>
    {
        IEnumerable<T> All { get; }
        long Count();

        void Delete(T t);

        void DeleteById(ID id);

        bool ExistsById(ID id);

        T FindById(ID id);

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindByIds(IEnumerable<ID> ids);

        T Save(T t);

        IEnumerable<T> Save(IEnumerable<T> entities);
    }
}
