using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryservice = categoryService;
            _mapper = mapper;
        }
        [HttpGet("categoryId:Guid")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid categoryId)
        {
            var value = await _categoryservice.GetById(categoryId);
            var result = _mapper.Map<CategoriesDTOs>(value);
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateCategory([FromBody] CategoriesDTOs category)
        {
            var value = await _categoryservice.CreateAsync(_mapper.Map<Category>(category));
            var result = _mapper.Map<CategoriesDTOs>(value);
            return CreatedAtAction(nameof(GetById),
                new
                {
                    categoryId = result.Id
                },
                result);
        }
    }
}
