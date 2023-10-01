using FileBaseContext.Abstractions.Models.FileSet;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.DataAccess.Context;

public interface IDataContext : IAsyncDisposable
{
    IFileSet<Answer, Guid> Answers { get;}
    IFileSet<CheckBoxQuestion, Guid> CheckBoxQuestions { get;}
    IFileSet<MultipleChoiceQuestion, Guid> MultipleChoiceQuestions { get;}
    IFileSet<ShortAnswerTypeQuestion, Guid> ShortAnswerTypeQuestions { get;}
    IFileSet<ShortAnswer, Guid> ShortAnswers { get;}
    IFileSet<User, Guid> Users { get;}
    IFileSet<Test, Guid> Tests { get; }
    IFileSet<UserAnswers, Guid> UserAnswers { get;}
    IFileSet<UserCredentials, Guid> UserCredentials { get;}
    IFileSet<Category, Guid> Categories { get;}
    
    ValueTask SaveChangesAsync();
}