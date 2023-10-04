using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMultipleChoiceQuestionService _multipleChoiceQuestionService;
        private readonly ICheckboxQuestionService _checkboxQuestionService;
        private readonly IShortAnswerTypeQuestionService _shortAnswerTypeQuestionService;
        private readonly IMapper _mapper;
        public QuestionsController(IMultipleChoiceQuestionService multipleChoiceQuestionService
            ,ICheckboxQuestionService checkboxQuestionService, IShortAnswerTypeQuestionService shortAnswerTypeQuestionService,
            IMapper mapper)
        {
            _multipleChoiceQuestionService = multipleChoiceQuestionService;
            _checkboxQuestionService = checkboxQuestionService;
            _shortAnswerTypeQuestionService = shortAnswerTypeQuestionService;
            _mapper = mapper;
        }
    }
}
