using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities.Answers;
using TestGorilla.Service.DTOs.Answers;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers;
    [ApiController]
    [Route("api/[controller]")]
public class AnswersController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAnswerService _answerService;

    public AnswersController(IMapper mapper, IAnswerService answerService)
    {
        _mapper = mapper;
        _answerService = answerService;
    }
 
    [HttpGet("answers/all")]
    public IActionResult GetAll([FromQuery] int pageToken, [FromQuery] int pageSize, [FromServices] IAnswerService _answerService)
    {
        var result = _answerService.Get(category => true).Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
        return result.Any() ? Ok(result) : NotFound();
    }
 
    [HttpGet("answers/by-id/{answerId:Guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid answerId)
    {
        var value = await _answerService.GetByIdAsync(answerId);
        
        var result = _mapper.Map<AnswerDto>(value);
       
        return Ok(result);
    }

    [HttpGet("answers/by-question-id/{answerQuestionId:Guid}")]
    public async ValueTask<IActionResult> GetByQuestionId([FromRoute] Guid answerQuestionId/*, Guid answerId = default(Guid)*/)
    {
        var value = await _answerService.GetByQuestionIdAsync(answerQuestionId);
        
        var result = _mapper.Map<ICollection<Answer>>(value);

        return Ok(result);
    }


    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] AnswerDto answer)
    {
        var value = await _answerService.CreateAsync(_mapper.Map<Answer>(answer));
        var result = _mapper.Map<AnswerDto>(value);
        return CreatedAtAction(nameof(GetById),
            new
            {
                answerId = result.Id
            },
            result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] AnswerDto answer)
    {
        var value = await _answerService.GetByIdAsync(answer.Id)
            ?? throw new FileNotFoundException("Answer not found");

        value.AnswerText = answer.AnswerText;
        value.QuestionId = answer.QuestionId;
         
        var result = _mapper.Map<AnswerDto>(
            await _answerService.UpdateAsync(_mapper.Map<Answer>(value)));

        return Ok(result);
    }

    [HttpDelete("{answerId:Guid}")]
    public async ValueTask<IActionResult> DeleteAnswer([FromRoute] Guid answerId)
    {
        var result = await _answerService.DeleteAsync(answerId);
        return Ok(result);
    }
}
