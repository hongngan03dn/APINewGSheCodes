using APINewG.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINewG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagsController(ITagRepository tagRepository) 
        {
            this._tagRepository = tagRepository;
        }

        [HttpGet("GetAllTagsAndCategories")]
        public async Task<IActionResult> GetAllTagsAndCategories()
        {
            var result = await _tagRepository.GetAllTagsAndCategories();
            return Ok(result);
        }

        [HttpPut("SaveTagsToIdUser")]
        public async Task<IActionResult> SaveTagsToIdUser(int IdUser, [FromBody] List<int> listIdTag)
        {
            try
            {
                await _tagRepository.SaveTagsToIdUser(IdUser, listIdTag);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}
