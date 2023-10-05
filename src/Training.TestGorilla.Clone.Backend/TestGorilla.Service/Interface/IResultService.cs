using System.Linq.Expressions;
using TestGorilla.Domain.Entities;

namespace TestGorilla.Service.Interface;

public interface IResultService
{
    ValueTask<Result> GetByIdAsync(Guid id);

    IQueryable<Result> Get(Expression<Func<Result, bool>> predicate);
    
    ValueTask<Result> CreateAsync(Result resut, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Result> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Result> DeleteAsync(Result result, bool saveChanges = true, CancellationToken cancellationToken = default);
    
    ValueTask<Result> UpdateAsync(Result result, bool saveChanges = true, CancellationToken cancellationToken = default);
}