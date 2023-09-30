using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Service.Interface;

public interface IAnswerService
{
    IQueryable<Answer> Get(Expression<Func<Answer, bool>> predicate);
    ValueTask<Answer> GetByIdAsync(Guid id);
    ValueTask<ICollection<Answer>> GetByQuestionIdAsync(Guid questionId); 
    ValueTask<Answer> CreateAsync(Answer answer, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<Answer> UpdateAsync(Answer answer, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<Answer> DeleteAsync(Guid answeId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
