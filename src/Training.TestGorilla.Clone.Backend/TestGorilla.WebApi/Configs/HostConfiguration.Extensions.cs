using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using Microsoft.Extensions.DependencyInjection;
using TestGorilla.DataAccess.Context;
using TestGorilla.Service.Interface;
using TestGorilla.Service.Service;

namespace TestGorilla.Api.Configs
{
    public static class HostConfiguration
    {
        public static WebApplicationBuilder AddDataContext(this WebApplicationBuilder builder)
        {
            var fileContextOptions = new FileContextOptions<AppFileContext>(Path.Combine(builder.Environment.ContentRootPath, "Data/Storage"));

            builder.Services.AddSingleton(fileContextOptions); // Remove generic type parameter
            builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
            {
                var options = provider.GetRequiredService<IFileContextOptions<AppFileContext>>(); // Change this line
                var dataContext = new AppFileContext(options);
                dataContext.FetchAsync().AsTask().Wait();

                return dataContext;
            });
            return builder;
        }
        
        

    }
}
