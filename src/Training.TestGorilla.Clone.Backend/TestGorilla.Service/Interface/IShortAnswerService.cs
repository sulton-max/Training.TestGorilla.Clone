using System.Linq.Expressions;
using TestGorilla.Domain.Entities.Answers;

namespace TestGorilla.Service.Interface;

public interface IShortAnswerService
{
    IQueryable<ShortAnswer> Get(Expression<Func<ShortAnswer, bool>> predicate);
    ValueTask<ShortAnswer> GetByIdAsync(Guid id);
    ValueTask<ShortAnswer> CreateAsync(ShortAnswer answer, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ShortAnswer> UpdateAsync(ShortAnswer answer, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ShortAnswer> DeleteAsync(Guid answeId, bool saveChanges = true, CancellationToken cancellationToken = default);
}
