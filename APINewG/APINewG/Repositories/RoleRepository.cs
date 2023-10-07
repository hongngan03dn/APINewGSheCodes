using APINewG.Entities;
using APINewG.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APINewG.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly testpbldbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(testpbldbContext context, IMapper mapper) 
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<List<RoleModel>>(roles);
        }
    }
}
