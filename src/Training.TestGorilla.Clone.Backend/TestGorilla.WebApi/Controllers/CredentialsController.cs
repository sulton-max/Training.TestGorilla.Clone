using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestGorilla.Domain.Entities.Users;
using TestGorilla.Service.Interface;

namespace TestGorilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IUserCredentialsService _userCredentialsService;
        private readonly IMapper _mapper;

        public CredentialsController(IUserCredentialsService userCredentialsService, IMapper mapper)
        {
            _userCredentialsService = userCredentialsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] IEnumerable<Guid> Ids)
        {
            var value = await _userCredentialsService.Get(Ids);
            return Ok(value);
        }

        [HttpGet("{userCredentialsId:guid}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid userCredentialsId)
        {
            var value = await _userCredentialsService.GetById(userCredentialsId);
            return Ok(value);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUserCredentials([FromBody] UserCredentials userCredentials)
        {
            var value = await _userCredentialsService.CreateAsync(userCredentials);
            return Ok(value);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateUserCredentials( string password, [FromBody] UserCredentials userCredentials)
        {
            var value = await _userCredentialsService.UpdateAsync(password, userCredentials);
            return Ok(value);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteUserCredentials(UserCredentials userCredentials)
        {
            var value = await _userCredentialsService.DeleteAsync(userCredentials);
            return Ok(value);
        }

        [HttpDelete("userCredentials:guid")]
        public async ValueTask<IActionResult> DeleteUserCredentialsById([FromRoute] Guid id)
        {
            var value = await _userCredentialsService.DeleteAsync(id);
            return Ok(value);
        }
    }
}