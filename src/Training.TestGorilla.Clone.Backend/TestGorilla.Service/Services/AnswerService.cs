using System.Linq.Expressions;
using TestGorilla.Data.Data;
using TestGorilla.Domain.Models;
using TestGorilla.Service.Services.Interfaces;

namespace TestGorilla.Service.Services;
public class AnswerService : IAnswerService
{
    private readonly IDataContext _appDataContext;

    public AnswerService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }
    public ValueTask<Answer>? GetByIdAsync(Guid id)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(ans => ans.Id == id);
        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer not found.");

        return new ValueTask<Answer>(searchingAnswer);
    }

    public async ValueTask<Answer> CreateAsync(Answer answer, bool saveChanges = true)
    {
        if (ValidateAnswer(answer) != true)
            throw new InvalidOperationException("Invalid answer.");
        await _appDataContext.Answers.AddAsync(answer);

        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        return answer;
    }

    public async ValueTask<Answer> DeleteAsync(Answer answer, bool saveChanges = true)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(ans => ans.Id == answer.Id);
        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer not found.");

        await _appDataContext.Answers.RemoveAsync(searchingAnswer);
        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        return searchingAnswer;
    }

    public async ValueTask<Answer> DeleteByIdAsync(Guid id, bool saveChanges = true)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(ans => ans.Id == id);
        if (searchingAnswer == null)
            throw new InvalidOperationException("User not found.");

        await _appDataContext.Answers.RemoveAsync(searchingAnswer);
        if (saveChanges)
            await _appDataContext.SaveChangesAsync();
        return searchingAnswer;
    }

    public async ValueTask<Answer> UpdateByIdAsync(Answer answer, bool saveChanges = true)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(ans => ans.Id == answer.Id);
        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer not found.");

        searchingAnswer.AnswerText = answer.AnswerText;
        searchingAnswer.IsCorrect = answer.IsCorrect;

        if (saveChanges)
            await _appDataContext.Answers.SaveChangesAsync();
        return searchingAnswer;
    }

    public bool ValidateAnswer(Answer answer) =>
        string.IsNullOrEmpty(answer.AnswerText);

    IQueryable IAnswerService.Get(Expression<Func<Answer, bool>> predicate)
    {
        return _appDataContext.Answers.Where(predicate.Compile()).AsQueryable();
    }
}
