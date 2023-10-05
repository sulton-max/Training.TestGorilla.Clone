using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("multi-choice/by-id/{questionId:Guid}")]
        public async ValueTask<IActionResult> GetById(Guid multipleChoiceId)
        {
            var value = await _multipleChoiceQuestionService.GetByIdAsync(multipleChoiceId);
            var result = _mapper.Map<MultipleChoiceDTOs>(value);
            return Ok(result);
        }

        [HttpGet("multi-choice/by-title/{title}")]
        public async ValueTask<IActionResult> GetByTitle(string MultipleChoiceTitle)
        {
            var value = await _multipleChoiceQuestionService.GetByTitleAsync(MultipleChoiceTitle, cancellationToken: default);
            var result = _mapper.Map<IEnumerable<MultipleChoiceDTOs>>(value);
            return Ok(result);
        }
        [HttpGet("multi-choice/by-category{categoryName}")]
        public async ValueTask<IActionResult> GetByCategory([FromRoute]string categoryName)
        {
            var value = await _multipleChoiceQuestionService.GetByCategoryAsync(categoryName, cancellationToken: default);
            var result = _mapper.Map<IEnumerable<MultipleChoiceDTOs>>(value);
            return Ok(result);
        }
        [HttpGet("multi-choice/all")]
        public async ValueTask<IActionResult> GetAll([FromQuery] int PageSize, [FromQuery] int PageToken)
        {
            var value = await _multipleChoiceQuestionService.GetAsync(question => true, PageToken, PageSize, cancellationToken: default);
            var result = _mapper.Map<PaginationResult<MultipleChoiceDTOs>>(value);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("check-box/by-id/{checkboxquestionId:Guid}")]
        public async ValueTask<IActionResult> GetByIdCheckBox(Guid checkboxquestionId)
        {
            var value = await _checkboxQuestionService.GetByIdAsync(checkboxquestionId, cancellationToken: default);
            var result = _mapper.Map<CheckboxDTOs>(value);
            return Ok(result);
        }
        [HttpGet("check-box/by-title/{title}")]
        public async ValueTask<IActionResult> GetByCheckboxTitle(string title)
        {
            var value = await _checkboxQuestionService.GetByTitleAsync(title, cancellationToken: default);
            var result = _mapper.Map<CheckboxDTOs>(value);
            return Ok(result);
        }
        [HttpGet("check-box/by-category/{categoryName}")]
        public async ValueTask<IActionResult> GetByCheckboxCategory([FromRoute]string category)
        {
            var value = await _checkboxQuestionService.GetByCategoryAsync(category, cancellationToken: default);
            var result = _mapper.Map<CheckboxDTOs>(value);
            return Ok(result);
        }
        [HttpGet("check-box")]
        public async ValueTask<IActionResult> GetAllCheckbox([FromQuery] int PageSize, [FromQuery] int PageToken)
        {
            var value = await _checkboxQuestionService.GetAsync(question => true, PageToken, PageSize, cancellationToken: default);
            var result = _mapper.Map<PaginationResult<CheckboxDTOs>>(value);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpPut("multi-choice")]
        public async ValueTask<IActionResult> UpdateMultipleChoice([FromBody] MultipleChoiceDTOs question)
        {
            var value = await _multipleChoiceQuestionService.UpdateAsync(_mapper.Map<MultipleChoiceQuestion>(question), cancellationToken: default);
            var result = _mapper.Map<MultipleChoiceQuestion>(value);
            return Ok("successFully!!");
        }
        [HttpDelete("multi-choice/by-id/{Id:Guid}")]
        public async ValueTask<IActionResult> DeleteQuestion([FromRoute]Guid Id)
        {
            await _multipleChoiceQuestionService.DeleteAsync(Id, cancellationToken: default);
            return Ok("SuccessFully!!");
        }
        [HttpPost("multi-choice")]
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
        [HttpPost("check-box")]
        public async ValueTask<IActionResult> CreateCheckbox([FromBody] CheckboxDTOs question)
        {
            var value = await _checkboxQuestionService.CreateAsync(_mapper.Map<CheckBoxQuestion>(question), cancellationToken: default);
            var result = _mapper.Map<CheckBoxQuestion>(value);
            return CreatedAtAction(nameof(GetByIdCheckBox),
                new
                {
                    checkboxquestionId = result.Id
                },
                result);
        }
        [HttpPut("check-box")]
        public async ValueTask<IActionResult> UpdateCheckbox([FromBody]CheckboxDTOs question)
        {
            var value = await _checkboxQuestionService.UpdateAsync(_mapper.Map<CheckBoxQuestion>(question), cancellationToken: default);
            var result = _mapper.Map<CheckBoxQuestion>(value);
            return Ok("Successfully!!");
        }
        [HttpDelete("check-box/by-id/{checkboxId:Guid}")]
        public async ValueTask<IActionResult> DeleteCheckbox([FromRoute] Guid checkboxId)
        {
            var value = _checkboxQuestionService.DeleteAsync(checkboxId, cancellationToken: default);
            return Ok("Successfully!!");
        }
    }
}
