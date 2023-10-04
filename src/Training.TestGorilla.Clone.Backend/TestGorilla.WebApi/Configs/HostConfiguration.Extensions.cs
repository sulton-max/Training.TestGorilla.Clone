using AutoMapper;
using FileBaseContext.Context.Models.Configurations;
using TestGorilla.DataAccess.Context;
using TestGorilla.Service.Helpers;
using TestGorilla.Service.Interface;
using TestGorilla.Service.Mappers;
using TestGorilla.Service.Service;

namespace TestGorilla.Api.Configs
{
    public static partial class HostConfiguration
    {
        // Bu qismida Biz Data Contextni Registratsiyadan O'tkazdik  
        public static WebApplicationBuilder AddDataContext(this WebApplicationBuilder builder)
        {
            var fileContextOptions = new FileContextOptions<AppFileContext>(Path.Combine(builder.Environment.ContentRootPath, "Storage"));

            builder.Services.AddSingleton<IFileContextOptions<AppFileContext>>(fileContextOptions); // Remove generic type parameter
            builder.Services.AddScoped<IDataContext, AppFileContext>(provider =>
            {
                var options = provider.GetRequiredService<IFileContextOptions<AppFileContext>>(); // Change this line
                var dataContext = new AppFileContext(options);
                dataContext.FetchAsync().AsTask().Wait();

                return dataContext;
            });
            return builder;
        }
        // Bu qismida Hamma O'zi Bajaryotgan Service ni Huddi User Service nikidek Registratsiya qilsin
        public static WebApplicationBuilder Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAnswerService, AnswerService>();
            builder.Services.AddScoped<ValidationService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IMultipleChoiceQuestionService, MultipleChoiceQuestionService>();
            builder.Services.AddScoped<ICheckboxQuestionService, CheckBoxQuestionService>();
            builder.Services.AddScoped<IShortAnswerTypeQuestionService, ShortAnswerTypeQuestionService>();
            builder.Services.AddScoped<ITestService, TestService>();
            return builder;
        }
        // Bu qismida Developerga kerak bo'ladigan narsalar registratsiyadan o'tdi
        public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            return builder;
        }
        // Bu qismi bizga Canfigure Async Methodini yozish uchun kerak 
        public static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
        // Bu qismida biz Controller va Route larni Ro'yxatdan o'tkazdik 
        public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddRouting();
            return builder;
        }
        //C# API'da, Route atributi bir so'rovni qaysi URL yo'lining va HTTP usuliga mos kelishini aniqlash uchun ishlatiladi
        // Route manabu narsa     [Route("api/[controller]")]
        // Http usuli deganda u Masalan [HttpGet],[HttpPost],va boshqalar nazarda tutuladi 
        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            builder.Services.AddSingleton<IMapper>(sp => mappingConfig.CreateMapper());
            return builder;
        }
    }
}
