using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Service.Interface;
using TestGorilla.Service.Helpers;
using TestGorilla.DataAccess.Context;
using System.Data;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using System;

namespace TestGorilla.Service.Service;
public class AnswerService : IAnswerService
{
    private readonly IDataContext _appDataContext;
    private Validator _validator;

    public AnswerService(IDataContext appDataContext, Validator validator)
    {
        _validator = validator;
        _appDataContext = appDataContext;
    }

    public IQueryable<Answer> Get(Expression<Func<Answer, bool>> predicate)
    {
        return _appDataContext.Answers.Where(predicate.Compile()).AsQueryable();
    }
    public ValueTask<Answer> GetByIdAsync(Guid answerId)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answerId);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer does not exist.");

        return new ValueTask<Answer>(searchingAnswer);
    }

    public ValueTask<ICollection<Answer>> GetByQuestionIdAsync(Guid questionId)
    {
        ICollection<Answer> QuestionsAnswers = new List<Answer>();
        
        _appDataContext.Answers.Select(answer =>
        {
            if (answer.QuestionId == questionId)
                QuestionsAnswers.Add(answer);
            return answer;
        });

        if (QuestionsAnswers.Count == 0)
            throw new InvalidOperationException("No answers based on the question's answers.");

        return new ValueTask<ICollection<Answer>>(QuestionsAnswers);
    }

    public ValueTask<Answer> CreateAsync(Answer answer)
    {
        if (_validator.IsValidTitle(answer.AnswerText) == false)
            throw new Exception();

        var isUniqueText = _appDataContext.Answers
            .FirstOrDefault(a => a.AnswerText == answer.AnswerText && a.Id == answer.Id && a.QuestionId == answer.QuestionId);
        
        if (isUniqueText == null)
            throw new DuplicateNameException("Data of this object is a duplicate of existing data in this question's answers.");

        _appDataContext.Answers.AddAsync(answer);

        return new ValueTask<Answer>(answer);
    }
    public ValueTask<Answer> UpdateAsync(Answer answer)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answer.Id);

        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer is not exist.");
        searchingAnswer.AnswerText = answer.AnswerText;
        searchingAnswer.UpdatedTime = DateTime.UtcNow;
        searchingAnswer.IsCorrect = answer.IsCorrect;

        return new ValueTask<Answer>(answer);
    }

    public ValueTask<Answer> DeleteAsync(Guid answeId)
    {
        var searchingAnswer = _appDataContext.Answers.FirstOrDefault(a => a.Id == answeId);
        
        if (searchingAnswer == null)
            throw new InvalidOperationException("Answer is not exists in this question.");

        searchingAnswer.IsDeleted = true;
        searchingAnswer.DeletedDate = DateTime.UtcNow;

        return new ValueTask<Answer>(searchingAnswer);
    }
}
