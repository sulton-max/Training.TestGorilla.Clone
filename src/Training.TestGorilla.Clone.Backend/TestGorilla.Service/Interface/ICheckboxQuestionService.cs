using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Questions;

namespace TestGorilla.Service.Interface;

public interface ICheckboxQuestionService
{
    public Task<CheckBoxQuestion> CreateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<CheckBoxQuestion> UpdateAsync(CheckBoxQuestion question, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<bool> DeleteAsync(Guid questionId, CancellationToken cancellationToken, bool saveChanges = true);
    
    public IQueryable<CheckBoxQuestion> Get(Expression<Func<CheckBoxQuestion, bool>> predicate, CancellationToken cancellationToken, bool saveChanges = true);

    public Task<PaginationResult<CheckBoxQuestion>> GetAsync(CheckBoxQuestion question, int PageToken, int PageSize,
        CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<CheckBoxQuestion> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<IEnumerable<CheckBoxQuestion>> GetByTitleAsync(string Title, CancellationToken cancellationToken, bool saveChanges = true);
    
    public Task<IEnumerable<CheckBoxQuestion>> GetByCategoryAsync(Category category, CancellationToken cancellationToken, bool saveChanges = true);
}
