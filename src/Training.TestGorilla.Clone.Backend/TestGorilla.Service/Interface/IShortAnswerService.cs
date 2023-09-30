using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Service.Interface;

public interface IShortAnswerService
{
    IQueryable<Answer> Get(Expression<Func<Answer, bool>> predicate);
    ValueTask<Answer> GetByIdAsync(Guid id);
    ValueTask<Answer> CreateAsync(Answer answer);
    ValueTask<Answer> UpdateAsync(Answer answer);
    ValueTask<Answer> DeleteAsync(Guid answeId);
    ValueTask<ICollection<Answer>> GetByQuestionIdAsync(Guid questionId);
}
