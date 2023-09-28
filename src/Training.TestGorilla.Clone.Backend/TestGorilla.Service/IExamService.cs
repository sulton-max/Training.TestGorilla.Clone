using System.Linq.Expressions;
using TestGorilla.Domain.Models;

namespace TestGorilla.Service
{
    public interface IExamService
    {
        Task<Exam> Createasync(Exam exam);
        bool DeleteById(Guid id);
        IQueryable<Exam> Get(Expression<Func<Exam, bool>> predicate);
        Task<PaginationResult<Exam>> GetByIdAsync(Guid id, int PageToken, int PageSize);
        Task<Exam> GetByTitleAsync(string title);
        Task<Exam> UpdateAsync(Exam exam);

    }
}
