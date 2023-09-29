using System.Linq.Expressions;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;

namespace TestGorilla.Service.Services.Interfaces;

public interface ICheckBoxQuestionService
{
    public Task<CheckBoxQuestion> CreateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    public bool DeleteAsync(Guid questionId,CancellationToken cancellationToken, bool saveChanges = true);
    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<PaginationResult<CheckBoxQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<CheckBoxQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<IEnumerable<CheckBoxQuestion>> GetByQuestionCategoryAsync(string category, CancellationToken cancellationToken, bool saveChanges = true);
}
