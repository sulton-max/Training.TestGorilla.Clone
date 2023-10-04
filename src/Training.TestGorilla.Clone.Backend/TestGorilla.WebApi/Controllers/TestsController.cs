using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.DTOs.Tests;
using TestGorilla.Service.Interface;
using TestGorilla.Service.Service;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        public TestsController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }


        [HttpGet("{testId:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid testId)
        {
            try
            {
                var test = await _testService.GetByIdAsync(testId);
                var testDto = _mapper.Map<TestsDtos>(test);
                return Ok(testDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateTest([FromBody] TestsDtos testDto)
        {
            try
            {
                var test = _mapper.Map<Test>(testDto);
                var createdTest = await _testService.CreateAsync(test);
                var createdTestDto = _mapper.Map<TestsDtos>(createdTest);
                return CreatedAtAction(nameof(GetById), new { testId = createdTestDto.Id }, createdTestDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tests = _testService.Get(test => true); // Get all tests
            var testDtos = _mapper.Map<IEnumerable<TestsDtos>>(tests);
            return Ok(testDtos);
        }

        [HttpPut("{testId:guid}")]
        public async ValueTask<IActionResult> UpdateTest([FromRoute] Guid testId, [FromBody] TestsDtos testDto)
        {
            try
            {
                var test = _mapper.Map<Test>(testDto);
                test.Id = testId;
                var updatedTest = await _testService.UpdateAsync(test);
                var updatedTestDto = _mapper.Map<TestsDtos>(updatedTest);
                return Ok(updatedTestDto);
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
                var deletedTestDto = _mapper.Map<TestsDtos>(deletedTest);
                return Ok(deletedTestDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
