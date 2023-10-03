/*using System.Linq.Expressions;
using TestGorilla.DataAccess.Context;
using TestGorilla.Domain.Entities;

namespace TestGorilla.Service.Service;

public class ResultSevice
{
    private readonly IDataContext _appDataContext;*/

   /* public ResultSevice(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }
*/
    /// <summary>
    /// Bu service result qo'shadi
    /// </summary>
    /// <param name="resut"></param>
    /// <returns></returns>
   /* public async ValueTask<Result> CreateAsync(Result resut)
    {
        return (await _appDataContext.Results.AddAsync(resut)).Entity;
    }*/
    /// <summary>
    /// Bu id boyicha ochiradi
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
   /* public async ValueTask<Result> DeleteAsync(Guid id)
    {
        var deleting = _appDataContext.Results.FirstOrDefault(x => x.Id == id);
        if (deleting == null)
            throw new Exception("Result is not found");

        deleting.IsDeleted = true;
        await _appDataContext.SaveChangesAsync();

        return deleting;
    }*/
    /// <summary>
    /// Bu ham id boyicha borligini tekshirib ochiradi
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>

   /* public async ValueTask<Result> DeleteAsync(Result result)
    {
        await DeleteAsync(result.Id);

        await _appDataContext.SaveChangesAsync();
        return result;
    }*/
    /// <summary>
    /// Bu malimotlarni hammasini olb beradi
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
   /* public IQueryable<Result> Get(Expression<Func<Result, bool>> predicate)
    {
        var getting = _appDataContext.Results.Where(predicate.Compile()).AsQueryable();
        return getting;
    }*/
    /// <summary>
    /// Bu id boyich olob beradi
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>

   /* public async ValueTask<Result> GetByIdAsync(Guid id)
    {
        var result = _appDataContext.Results.FirstOrDefault(a => a.Id == id);
        if (result == null)
            throw new Exception();
        return result;
    }*/
   /// <summary>
   /// Bu hammasini update qiladi 
   /// </summary>
   /// <param name="result"></param>
   /// <returns></returns>
   /// <exception cref="Exception"></exception>
  /*  public async ValueTask<Result> UpdateAsync(Result result)
    {
        var entity = _appDataContext.Results.FirstOrDefault(a => a.Id == result.Id);
        if (entity == null)
            throw new Exception();

        entity.UpdatedTime = DateTime.UtcNow;
        entity.TestResult = result.TestResult;
        entity.ExamResult = result.ExamResult;
        entity.CategoryId = result.CategoryId;
        entity.UserId = result.UserId;

        await _appDataContext.SaveChangesAsync();
        return entity;
    }
    
}
*/