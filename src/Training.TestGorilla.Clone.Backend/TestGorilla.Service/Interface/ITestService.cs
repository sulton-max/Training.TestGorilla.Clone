using System.Linq.Expressions;
using TestGorilla.Domain.Entities;

namespace TestGorilla.Service.Interface;

public interface ITestService
{
    IQueryable<Test> Get(Expression<Func<Test, bool>> predicate);

    ValueTask<Test> GetByIdAsync(Guid id);

    ValueTask<Test> CreateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Test> UpdateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Test> DeleteAsync(Guid test, bool saveChanges = true, CancellationToken cancellationToken = default);
}