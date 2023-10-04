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
        public async ValueTask<IActionResult> GetById(Guid categoryId)
        {
            var value = await _categoryservice.GetById(categoryId);
            var result = _mapper.Map<CategoriesDTOs>(value);
            
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAllCategory([FromQuery] int pageToken, [FromQuery] int pageSize, [FromServices] ICategoryService categoryService)
        {
            var result = categoryService.Get(category => true).Skip((pageToken - 1)  * pageSize).Take(pageSize).ToList();
            return result.Any() ? Ok(result) : NotFound();
        } 
            
        [HttpPost]
        public async ValueTask<IActionResult> CreateCategory([FromBody] CategoriesDTOs category)
        {
            var value = await _categoryservice.CreateAsync(_mapper.Map<Category>(category));
            var result = _mapper.Map<CategoriesDTOs>(value);
            return CreatedAtAction(nameof(GetById),
                new
                {
                    categoryId = result.Id,
                    
                },
                result);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateCtegory([FromBody] CategoriesDTOs categories)
        {
            var existingCategory = await _categoryservice.GetById(categories.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.CategoryName = categories.CategoryName;
            var updateResult = await _categoryservice.UpdateAsync(existingCategory);
            if(updateResult == null)
            {
                return BadRequest("Failed to update!!");
            }
            var updateCategoryDTOs = _mapper.Map<CategoriesDTOs>(updateResult);
            return Ok(updateCategoryDTOs);  
        }
        
    }
}
