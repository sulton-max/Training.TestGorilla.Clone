namespace TestGorilla.Api.Configs
{
    public static partial class HostConfiguration
    {
        //Bu qismiga hech kim tegmasin
        public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
        {
            builder.AddAutoMapper();
            builder.AddDataContext();
            builder.Services();
            builder.AddDevTools();
            builder.AddExposers();
            return builder;
        }
        //Bungaham
        public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
        {
            app.UseDevTools();
            return app;
        }
    }
}
