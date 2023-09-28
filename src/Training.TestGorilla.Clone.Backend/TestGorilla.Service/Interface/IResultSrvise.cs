using System.Linq.Expressions;
using TestGorilla.Domain.Models;

namespace TestGorilla.Service.Interface;

public interface IResultSrvise
{
    IQueryable<Result> Get(Expression<Func<Result, bool>> predicate);

    ValueTask<Result?> GetByIdAsync(Guid id);

    ValueTask<Result> CreateAsync(Result resut);

    ValueTask<Result> UpdateAsync(Result Result);

    ValueTask<Result> DeleteAsync(Guid id);

    ValueTask<Result> DeleteAsync(Result Result);
}