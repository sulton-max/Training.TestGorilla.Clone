namespace TestGorilla.Api.Configs
{
    public class HostConfiguration
    {
        public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
        {
            builder.AddDataContext();
            builder.Services();
            builder.AddDevTools();
            return builder;
        }
        public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app.UseDevTools();
        }
    }
}
