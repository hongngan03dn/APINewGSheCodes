using APINewG.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINewG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly testpbldbContext _context;

        public RolesController(testpbldbContext ctx) 
        {
            _context = ctx;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_context.Roles.ToList());
        }
    }
}
