using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using TestGorilla.Domain.Commons;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Domain.Entities.Users;

namespace TestGorilla.DataAccess.Context;

public class AppFileContext : FileContext, IDataContext
{

    //  public IFileSet<User, Guid> Users => Set<User>(nameof(Users));
    public IFileSet<Answer, Guid> Answers => Set<Answer, Guid>(nameof(Answers));

    public IFileSet<CheckBoxQuestion, Guid> CheckBoxQuestions => Set<CheckBoxQuestion, Guid>(nameof(CheckBoxQuestions));

    public IFileSet<MultipleChoiceQuestion, Guid> MultipleChoiceQuestions => Set<MultipleChoiceQuestion, Guid>(nameof(MultipleChoiceQuestions));

    public IFileSet<ShortAnswerTypeQuestion, Guid> ShortAnswerTypeQuestions => Set<ShortAnswerTypeQuestion, Guid>(nameof(ShortAnswerTypeQuestions));

    public IFileSet<ShortAnswer, Guid> ShortAnswers => Set<ShortAnswer, Guid>(nameof(ShortAnswers));

    public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

    public IFileSet<Test, Guid> Tests => Set<Test, Guid>(nameof(Tests));

    public IFileSet<Result, Guid> Results => Set<Result, Guid>(nameof(Results));

    public IFileSet<UserAnswers, Guid> UserAnswers => Set<UserAnswers, Guid>(nameof(UserAnswers));

    public IFileSet<UserCredentials, Guid> UserCredentials => Set<UserCredentials, Guid>(nameof(UserCredentials));

    public IFileSet<Category, Guid> Categories => Set<Category, Guid>(nameof(Categories));

    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
        OnSaveChanges += AddAuditableDetails;
        OnSaveChanges += AddSoftDeletionDetails;
    }

    public ValueTask AddPrimaryKeys(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<IEntity> entityEntry) continue;

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.Id = Guid.NewGuid();

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
            }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddAuditableDetails(IEnumerable<IFileSetBase> fileSets)
    {
        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                if (entry is not IFileEntityEntry<Auditable> entityEntry) continue;

                if (entityEntry.State == FileEntityState.Added)
                    entityEntry.Entity.CreatedTime = DateTime.Now;

                if (entityEntry.State == FileEntityState.Modified)
                    entityEntry.Entity.UpdatedTime = DateTime.Now;

                if (entry is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
            }

        return new ValueTask(Task.CompletedTask);
    }

    public ValueTask AddSoftDeletionDetails(IEnumerable<IFileSetBase> fileSets)
    {
        var hardDeletedEntities = new List<Type>()
        {
        };

        foreach (var fileSet in fileSets)
            foreach (var entry in fileSet.GetEntries())
            {
                // Skip entities that are not soft deletable
                if (entry is not IFileEntityEntry<Auditable> { State: FileEntityState.Deleted } entityEntry) continue;

                // Skip hard deleted entities
                if (hardDeletedEntities.Contains(entityEntry.Entity.GetType())) continue;

                // Soft delete all entities except PostView
                entityEntry.Entity.IsDeleted = true;
                entityEntry.Entity.DeletedDate = DateTime.Now;
                entityEntry.State = FileEntityState.MarkedDeleted;
            }

        return new ValueTask(Task.CompletedTask);
    }



    public ValueTask DisposeAsync()
    {
        return new ValueTask(Task.CompletedTask);
    }
}
