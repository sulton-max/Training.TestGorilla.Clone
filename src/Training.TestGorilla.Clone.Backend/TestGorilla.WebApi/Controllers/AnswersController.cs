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
 
    [HttpGet("{answerId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid answerId)
    {
        var value = await _answerService.GetByIdAsync(answerId);
        var result = _mapper.Map<AnswerDto>(value);
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

}
