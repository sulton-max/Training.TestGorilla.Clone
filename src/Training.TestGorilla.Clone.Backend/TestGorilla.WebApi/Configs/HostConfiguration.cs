namespace TestGorilla.Api.Configs
{
    public static partial class HostConfiguration
    {
        public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
        {
            builder.AddDataContext();
            builder.Services();
            builder.AddDevTools();
            builder.AddExposers();
            return builder;
        }
        public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app.UseDevTools();
            return app;
        }
    }
}
