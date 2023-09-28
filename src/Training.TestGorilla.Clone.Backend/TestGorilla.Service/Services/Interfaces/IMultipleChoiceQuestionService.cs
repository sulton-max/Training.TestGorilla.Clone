using System.Linq.Expressions;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;

namespace TestGorilla.Service.Services.Interfaces;

public interface IMultipleChoiceQuestionService
{
    public Task<MultipleChoiceQuestion> Createasync(MultipleChoiceQuestion question, bool saveChanges = true);
    public Task<MultipleChoiceQuestion> UpdateAsync(MultipleChoiceQuestion question, bool saveChanges = true);
    public bool DeleteAsync(Guid questionId,CancellationToken cancellationToken, bool saveChanges = true);
    public IQueryable<MultipleChoiceQuestion> Get(Expression<Func<MultipleChoiceQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<PaginationResult<MultipleChoiceQuestion>> GetByQuestionIdAsync(Guid id, int PageToken, int PageSize, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<MultipleChoiceQuestion> GetByQuestionTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
    public Task<IEnumerable<MultipleChoiceQuestion>> GetByQuestionCategoryAsync(string category, CancellationToken cancellationToken, bool saveChanges = true);
}
