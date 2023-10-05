using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.DTOs.Users;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] int PageSize, [FromQuery]int PageToken)
        {
            var value = await _userService.Get(user => true, PageToken, PageSize);

            var result = _mapper.Map<PaginationResult<UserDto>>(value);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
        {
            var value =  await _userService.GetByIdAsync(userId);
            var result = _mapper.Map<UserDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser([FromBody] UserDto user)
        {
            var value = await _userService.CreateAsync(_mapper.Map<User>(user));
            var result = _mapper.Map<UserDto>(value);
            return CreatedAtAction(nameof(GetById),
                new
                {
                    userId = result.Id
                },
                result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            await _userService.UpdateAsync(_mapper.Map<User>(user));
            return Ok();
        }

        [HttpDelete("{userId:guid}")]
        public async ValueTask<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }
    }
}
