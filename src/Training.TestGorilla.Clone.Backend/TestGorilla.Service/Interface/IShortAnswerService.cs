using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Service.Interface;

public interface IShortAnswerService
{
    IQueryable<ShortAnswer> Get(Expression<Func<ShortAnswer, bool>> predicate);
    ValueTask<ShortAnswer> GetByIdAsync(Guid id);
    ValueTask<ShortAnswer> CreateAsync(ShortAnswer answer);
    ValueTask<ShortAnswer> UpdateAsync(ShortAnswer answer);
    ValueTask<ShortAnswer> DeleteAsync(Guid answeId);
    ValueTask<ICollection<ShortAnswer>> GetByQuestionIdAsync(Guid questionId);
}
