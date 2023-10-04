using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.Interface;

namespace TestGorilla.Service.Service;

public class ResultSevice : IResultService
{
    private readonly IDataContext _appDataContext;

    public ResultSevice(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<Result> CreateAsync(Result resut, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        IsValidToCreate(resut);

        await _appDataContext.Results.AddAsync(resut);

        if (saveChanges)
        {
            await _appDataContext.Results.SaveChangesAsync();
        }

        return resut;
    }

    public async ValueTask<Result> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var deleted = await GetByIdAsync(id);

        if (deleted is null)
        {
            throw new ArgumentOutOfRangeException("Result does not exists");
        }

        deleted.IsDeleted = true;
        deleted.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
        {
            await _appDataContext.Results.SaveChangesAsync();
        }

        return deleted;
    }

    public async ValueTask<Result> DeleteAsync(Result result, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var deleted = await GetByIdAsync(result.Id);

        if (deleted is null)
        {
            throw new ArgumentOutOfRangeException("Result does not exists");
        }

        deleted.IsDeleted = true;
        deleted.DeletedDate = DateTime.UtcNow;

        if (saveChanges)
        {
            await _appDataContext.Results.SaveChangesAsync();
        }

        return deleted;
    }

    public IQueryable<Result> Get(Expression<Func<Result, bool>> predicate) =>
        _appDataContext.Results.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Result> GetByIdAsync(Guid id)
    {
        var getting = await _appDataContext.Results.FindAsync(id);

        if (getting is null || getting.IsDeleted)
            throw new ArgumentOutOfRangeException("Result is not found");

        return getting;
    }

    public async ValueTask<Result> UpdateAsync(Result result, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        IsValidToUpdate(result);

        var updated = await GetByIdAsync(result.Id);

        if (updated is null)
            throw new ArgumentOutOfRangeException("The given Result is not found");

        updated.UserId = result.UserId;
        updated.TestId = result.TestId;
        updated.ExamId = result.ExamId;
        updated.CategoryId = result.CategoryId;
        updated.TestResult = result.TestResult;
        updated.ExamResult = result.ExamResult;

        if (saveChanges)
        {
            await _appDataContext.Results.UpdateAsync(updated);
        }

        return updated;
    }

    private bool IsExistsResult(Guid id)
    {
        if (_appDataContext.Results.Any(result => result.Id == id)) return true;

        return false;
    }

    private bool IsValidToCreate(Result userResult)
    {
        if (IsExistsResult(userResult.Id))
            throw new InvalidOperationException("The given result already exists");

        return true;
    }

    private bool IsValidToUpdate(Result userResult)
    {
        if (!IsExistsResult(userResult.Id))
            throw new InvalidOperationException("Result doesn't exists");

        return true;
    }
}