using System.Linq.Expressions;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;

namespace TestGorilla.Service.Services.Interfaces;

public interface ICheckBoxQuestionService
{
    public Task<CheckBoxQuestion> CreateAsync(CheckBoxQuestion question, bool saveChanges = true);
    public Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question, bool saveChanges = true);
    public bool DeleteAsync(Guid questionId);
    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate);
    public Task<PaginationResult<CheckBoxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize);
    public Task<CheckBoxQuestion> GetByQuestionTitleAsync(string Title);
    public Task<IEnumerable<CheckBoxQuestion>> GetByQuestionCategoryAsync(string category);
}
