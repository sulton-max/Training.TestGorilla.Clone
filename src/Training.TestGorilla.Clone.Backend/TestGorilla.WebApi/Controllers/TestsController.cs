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

        // POST: TestsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
