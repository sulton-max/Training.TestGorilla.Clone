using System.Linq.Expressions;
using TestGorilla.Domain.Models;

namespace TestGorilla.Service.Services.Interfaces;

public interface IAnswerService
{
    IQueryable Get(Expression<Func<Answer, bool>> predicate);
    ValueTask<Answer>? GetByIdAsync(Guid id);
    ValueTask<Answer> CreateAsync(Answer answer, bool saveChanges = true);
    ValueTask<Answer> UpdateByIdAsync(Answer answer, bool saveChanges = true);
    ValueTask<Answer> DeleteAsync(Answer answer, bool saveChanges = true);
    ValueTask<Answer> DeleteByIdAsync(Guid id, bool saveChanges = true);
    bool ValidateAnswer(Answer answer);
}
