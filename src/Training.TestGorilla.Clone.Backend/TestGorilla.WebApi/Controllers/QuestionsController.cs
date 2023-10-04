using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities.Questions;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.DTOs.Questions;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMultipleChoiceQuestionService _multipleChoiceQuestionService;
        private readonly ICheckboxQuestionService _checkboxQuestionService;
        private readonly IShortAnswerTypeQuestionService _shortAnswerTypeQuestionService;
        private readonly IMapper _mapper;
        public QuestionsController(IMultipleChoiceQuestionService multipleChoiceQuestionService
            , ICheckboxQuestionService checkboxQuestionService, IShortAnswerTypeQuestionService shortAnswerTypeQuestionService,
            IMapper mapper)
        {
            _multipleChoiceQuestionService = multipleChoiceQuestionService;
            _checkboxQuestionService = checkboxQuestionService;
            _shortAnswerTypeQuestionService = shortAnswerTypeQuestionService;
            _mapper = mapper;
        }
        [HttpGet("{multipleChoiceId:Guid}")]
        public async ValueTask<IActionResult> GetById(Guid multipleChoiceId)
        {
            var value = await _multipleChoiceQuestionService.GetByIdAsync(multipleChoiceId);
            var result = _mapper.Map<MultipleChoiceDTOs>(value);
            return Ok(result);
        }
        [HttpGet("{MultipleChoiceTitle}")]
        public async ValueTask<IActionResult> GetByTitle(string Title)
        {
            var value = await _multipleChoiceQuestionService.GetByTitleAsync(Title, cancellationToken: default);
            var result = _mapper.Map<MultipleChoiceDTOs>(value);
            return Ok(result);
        }

        [HttpPost("MultipleChoice")]
        public async ValueTask<IActionResult> CerateMultipleChoice([FromBody] MultipleChoiceDTOs question)
        {
            var value = await _multipleChoiceQuestionService.CreateAsync(_mapper.Map<MultipleChoiceQuestion>(question), cancellationToken: default);
            var result = _mapper.Map<MultipleChoiceQuestion>(value);
            return CreatedAtAction(nameof(GetById),
                new
                {
                    multipleChoiceId = result.Id
                },
                result);
        }
    }
}
