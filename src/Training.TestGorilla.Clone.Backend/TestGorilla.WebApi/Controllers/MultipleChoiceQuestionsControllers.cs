using Microsoft.AspNetCore.Mvc;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class MultipleChoiceQuestionsControllers : ControllerBase
    {
        private readonly IMultipleChoiceQuestionService _multipleChoiceQuestionService;
        public MultipleChoiceQuestionsControllers(IMultipleChoiceQuestionService multipleChoiceQuestionService)
        {
            _multipleChoiceQuestionService = multipleChoiceQuestionService;
        }
        [HttpGet("questionId:guid")]

    }
}
