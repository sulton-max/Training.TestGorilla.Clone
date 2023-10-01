using System.Linq.Expressions;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Questions;

namespace TestGorilla.Service.Interface;

public interface IMultipleChoiceQuestionService
{
    public Task<MultipleChoiceQuestion> CreateAsync(MultipleChoiceQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<MultipleChoiceQuestion> UpdateAsync(MultipleChoiceQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true);
    
    public IQueryable<MultipleChoiceQuestion> Get(Expression<Func<MultipleChoiceQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);

    public Task<PaginationResult<MultipleChoiceQuestion>> GetAsync(MultipleChoiceQuestion question, int PageToken, int PageSize,
        CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<MultipleChoiceQuestion> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<IEnumerable<MultipleChoiceQuestion>> GetByTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<IEnumerable<MultipleChoiceQuestion>> GetByCategoryAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true);
}