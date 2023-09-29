using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services;

public class ResultServise : IResultSrvise
{
    private readonly IDataContext _appDataContext;

    public ResultServise(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<Result> CreateAsync(Result resut)
    {
        return (await _appDataContext.Results.AddAsync(resut)).Entity;
    }

    public async ValueTask<Result> DeleteAsync(Guid id)
    {
        var deleting = _appDataContext.Results.FirstOrDefault(x => x.Id == id);
        if (deleting == null)
            throw new Exception("Result is not found");

        deleting.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();

        return deleting;
    }

    public async ValueTask<Result> DeleteAsync(Result result)
    {
        result.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();
        return result;
    }

    public IQueryable<Result> Get(Expression<Func<Result, bool>> predicate)
    {
        var getting = _appDataContext.Results.Where(predicate.Compile()).AsQueryable();
        return getting;
    }

    public async ValueTask<Result?> GetByIdAsync(Guid id)
    {
        var result = _appDataContext.Results.FirstOrDefault(a => a.Id == id);
        if (result == null)
            throw new Exception();
        return result;
    }

    public async ValueTask<Result> UpdateAsync(Result result)
    {
        var entity = _appDataContext.Results.FirstOrDefault(a => a.Id == result.Id);
        if (entity == null)
            throw new Exception();

        entity.UpdateTime = DateTime.UtcNow;
        entity.TestResult = result.TestResult;
        entity.ExamResult = result.ExamResult;
        entity.CategoryId = result.CategoryId;
        entity.UserId = result.UserId;

        await _appDataContext.SaveChangesAsync();
        return entity;
    }

}