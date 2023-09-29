using FileBaseContext.Abstractions.Models.FileSet;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Question;
using TestGorilla.Domain.Models.Questions;

namespace TestGorilla.Data.Data
{
    public interface IDataContext : IAsyncDisposable
    {
        IFileSet<Answer, Guid> Answers { get; }
        IFileSet<Category, Guid> Categories { get; }
        IFileSet<Exam, Guid> Exams { get; }
        IFileSet<Result, Guid> Results { get; }
        IFileSet<Test, Guid> Tests { get; }
        IFileSet<User, Guid> Users { get; }
        IFileSet<UserCredentials, Guid> UserCredentials { get; }
        IFileSet<CheckBoxQuestion, Guid> CheckboxQuestions { get; }
        IFileSet<MultipleChoiceQuestion, Guid> MultipleQuestions { get; }
        IFileSet<ShortAnswerTypeQuestion, Guid> ShortQuestions { get; }
        ValueTask SaveChangesAsync();
    }
}