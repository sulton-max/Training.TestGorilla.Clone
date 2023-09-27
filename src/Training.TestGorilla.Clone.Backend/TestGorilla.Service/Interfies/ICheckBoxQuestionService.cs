using System.Linq.Expressions;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;

namespace TestGroilla.Service;

public interface ICheckBoxQuestionService
{
    public Task<CheckBoxQuestion> Createasync(CheckBoxQuestion question);
    public Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question);
    public bool DeleteAsync(Guid questionId);
    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate);
    public Task<PaginationResult<CheckBoxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize);
    public Task<CheckBoxQuestion> GetByQuestionTitleAsync(string Title);
    public Task<IEnumerable<CheckBoxQuestion>> GetByQuestionCategoryAsync(string category);
}
