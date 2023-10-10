using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
using TestGorilla.Service.DTOs.Categories;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet("{categoryId:guid}")]
        public async ValueTask<IActionResult> GetById(Guid categoryId)
        {
            var value = await _categoryService.GetById(categoryId);
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
            var value = await _categoryService.CreateAsync(_mapper.Map<Category>(category));
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
            var existingCategory = await _categoryService.GetById(categories.Id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.CategoryName = categories.CategoryName;
            var updateResult = await _categoryService.UpdateAsync(existingCategory);
            if(updateResult == null)
            {
                return BadRequest();
            }
            var updateCategoryDTOs = _mapper.Map<CategoriesDTOs>(updateResult);
            return Ok();  
        }
        [HttpDelete("{categoryId:Guid}")]
        public async ValueTask<IActionResult> DeleteCategory([FromRoute] Guid categoryId)
        {
          var deltingCategory = await _categoryService.GetById(categoryId);
            if(deltingCategory == null)
            {
                return NotFound();
            }
            var delete = await _categoryService.DeleteAsync(deltingCategory.Id);
            if (delete == null)
            {
                return BadRequest();
            }
            _mapper.Map<CategoriesDTOs>(delete);
            return Ok();
        }
        
    }
}
