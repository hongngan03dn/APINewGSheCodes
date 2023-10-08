using APINewG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINewG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        [HttpGet("GetNearestRoadmates")]
        public async Task<IActionResult> GetNearestRoadmates(int IdUser)
        {
            var result = await _userRepository.GetNearestRoadmates(IdUser);
            return Ok(result);
        }
        [HttpGet("GetSuggestedRoadmates")]
        public async Task<IActionResult> GetSuggestedRoadmates(int IdUser)
        {
            var result = await _userRepository.GetSuggestedRoadmates(IdUser);
            return Ok(result);
        }
    }
}
