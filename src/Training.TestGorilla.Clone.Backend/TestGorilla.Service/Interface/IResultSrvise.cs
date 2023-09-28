using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestGorilla.Domain.Models;

namespace TestGorilla.Service.Interface
{
    public interface IResultSrvise
    {
        IQueryable<Result> Get(Expression<Func<Result, bool>> predicate);

        ValueTask<Result?> GetByIdAsync(Guid id);

        ValueTask<Result> CreateAsync(Result resut);

        ValueTask<Result> UpdateAsync(Result Result);

        ValueTask<Result> DeleteAsync(Guid id);

        ValueTask<Result> DeleteAsync(Result Result);
    }
}
