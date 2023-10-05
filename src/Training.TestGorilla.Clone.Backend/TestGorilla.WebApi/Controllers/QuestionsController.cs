using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
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

        [HttpGet("multi-choice/{questionId:Guid}")]
        public async ValueTask<IActionResult> GetById(Guid multipleChoiceId)
        {
            var value = await _multipleChoiceQuestionService.GetByIdAsync(multipleChoiceId);
            var result = _mapper.Map<MultipleChoiceDTOs>(value);
            return Ok(result);
        }

        [HttpGet("{multipleChoicetitle}")]
        public async ValueTask<IActionResult> GetByTitle(string MultipleChoiceTitle)
        {
            var value = await _multipleChoiceQuestionService.GetByTitleAsync(MultipleChoiceTitle, cancellationToken: default);
            var result = _mapper.Map<IEnumerable<MultipleChoiceDTOs>>(value);
            return Ok(result);
        }
        [HttpGet("{categoryName}")]
        public async ValueTask<IActionResult> GetByCategory([FromRoute]string categoryName)
        {
            var value = await _multipleChoiceQuestionService.GetByCategoryAsync(categoryName, cancellationToken: default);
            var result = _mapper.Map<IEnumerable<MultipleChoiceDTOs>>(value);
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
        [HttpPut("multiplechoice")]
        public async ValueTask<IActionResult> UpdateMultipleChoice([FromBody] MultipleChoiceDTOs question)
        {
            var value = await _multipleChoiceQuestionService.UpdateAsync(_mapper.Map<MultipleChoiceQuestion>(question), cancellationToken: default);
            var result = _mapper.Map<MultipleChoiceQuestion>(value);
            return Ok("successFully!!");
        }
        [HttpDelete("{multiplechoiceId:Guid}")]
        public async ValueTask<IActionResult> DeleteQuestion(Guid multiplechoiceId)
        {
            await _multipleChoiceQuestionService.DeleteAsync(multiplechoiceId, cancellationToken: default);
            return Ok("SuccessFully!!");
        }
    }
}
