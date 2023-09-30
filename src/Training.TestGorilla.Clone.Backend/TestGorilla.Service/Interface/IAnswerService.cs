using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Service.Interface;

public interface IAnswerService
{
    IQueryable<Answer> Get(Expression<Func<Answer, bool>> predicate);
    ValueTask<Answer> GetByIdAsync(Guid id);
    ValueTask<Answer> CreateAsync(Answer answer);
    ValueTask<Answer> UpdateAsync(Answer answer);
    ValueTask<Answer> DeleteAsync(Guid answeId);
    ValueTask<ICollection<Answer>> GetByQuestionIdAsync(Guid questionId);
}
