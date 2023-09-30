using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.Service.Interface;

public interface IAnswerService
{
    IQueryable<Answer> Get();
    ValueTask<Answer> GetByIdAsync(Guid id);
    ValueTask<Answer> CreateAsync(Answer answer);
    ValueTask<Answer> UpdateAsync(Answer answer);
    ValueTask<Answer> DeleteAsync(Guid answeId);
}
