using System.Linq.Expressions;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Tests;

namespace TestGorilla.Service.Interface;

public interface ITestService
{
    Task<PaginationResult<Test>> Get(Expression<Func<Test, bool>> predicate, int PageToken, int PageSize);

    ValueTask<Test> GetByIdAsync(Guid id);

    ValueTask<Test> CreateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Test> UpdateAsync(Test test, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Test> DeleteAsync(Guid test, bool saveChanges = true, CancellationToken cancellationToken = default);
}