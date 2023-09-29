using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.DataAccess.Context;

public class AppFileContext : FileContext, IDataContext
{
    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }
  //  public IFileSet<User, Guid> Users => Set<User>(nameof(Users));
    public IFileSet<Answer, Guid> Answers => Set<Answer>(nameof(Answers));

    public IFileSet<CheckBoxQuestion, Guid> CheckBoxQuestions => Set<CheckBoxQuestion>(nameof(CheckBoxQuestions));

    public IFileSet<MultipleChoiceQuestion, Guid> MultipleChoiceQuestions => Set<MultipleChoiceQuestion>(nameof(CheckBoxQuestions));

    public IFileSet<ShortAnswerTypeQuestion, Guid> ShortAnswerTypeQuestions => Set<ShortAnswerTypeQuestion>(nameof(ShortAnswerTypeQuestions));

    public IFileSet<User, Guid> Users => Set<User>(nameof(Users));

    public IFileSet<UserAnswers, Guid> UserAnswers => Set<UserAnswers>(nameof(UserAnswers));

    public IFileSet<UserCredential, Guid> UserCredentials => Set<UserCredential>(nameof(UserCredentials));

    public IFileSet<Category, Guid> Categories => Set<Category>(nameof(Categories));

    public virtual ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSetBase in fileSets)
        {
            if (fileSetBase is not IFileSet<IFileSetEntity<Guid>, Guid> fileSet) continue;

            foreach (var entry in fileSet.Where(entry => entry.Id == default))
                entry.Id = Guid.NewGuid();
        }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}