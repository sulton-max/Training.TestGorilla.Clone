﻿using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using TestGorilla.Domain.Models;
using TestGorilla.Domain.Models.Questions;

namespace TestGorilla.Data.Data;
public class AppFileContext : FileContext ,IDataContext
{
    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) : base(fileContextOptions)
    {
        OnSaveChanges += AddPrimaryKeys;
    }

    public IFileSet<Answer, Guid> Answers => Set<Answer>(nameof(Answers));

    public IFileSet<Category, Guid> Categories => Set<Category>(nameof(Categories));

    public IFileSet<Exam, Guid> Exams => Set<Exam>(nameof(Exams));

    public IFileSet<Result, Guid> Result => Set<Result>(nameof(Result));

    public IFileSet<Test, Guid> Tests => Set<Test>(nameof(Tests));

    public IFileSet<User, Guid> Users => Set<User>(nameof(Users));

    public IFileSet<CheckboxQuestion, Guid> CheckboxQuestions => Set<CheckboxQuestion>(nameof(CheckboxQuestions));

    public IFileSet<MultipleQuestion, Guid> MultipleQuestions => Set<MultipleQuestion>(nameof(MultipleQuestions));

    public IFileSet<ShortQuestion, Guid> ShortQuestions => Set<ShortQuestion>(nameof(ShortQuestions));

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

    public ValueTask SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}