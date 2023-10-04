using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController : ControllerBase
{
    private readonly ITestService _testService;

    public TestsController(ITestService testService)
    {
        _testService = testService;
        
    }

    [HttpGet("{testId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid testId)
    {
        try
        {
            var test = await _testService.GetByIdAsync(testId);
            return Ok(test);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tests = _testService.Get(test => true);
        return Ok(tests);
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateTest([FromBody] Test test)
    {
        try
        {
            var createdTestDto = await _testService.CreateAsync(test);
            return CreatedAtAction(nameof(GetById), new { testId = createdTestDto.Id }, createdTestDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{testId:guid}")]
    public async ValueTask<IActionResult> UpdateTest([FromRoute] Guid testId, [FromBody] Test test)
    {
        try
        {
            test.Id = testId;
            var updatedTest = await _testService.UpdateAsync(test);
            return Ok(updatedTest);
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{testId:guid}")]
    public async ValueTask<IActionResult> DeleteTest([FromRoute] Guid testId)
    {
        try
        {
            var deletedTest = await _testService.DeleteAsync(testId);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
