using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;

namespace TestGorilla.DataAccess.Context;

public class AppFileContext : FileContext, IDataContext
{
    public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
    {
    }
}