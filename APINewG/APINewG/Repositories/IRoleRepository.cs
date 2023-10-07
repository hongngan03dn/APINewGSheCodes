using APINewG.Models;

namespace APINewG.Repositories
{
    public interface IRoleRepository
    {
        public Task<List<RoleModel>> GetAllRoles();
    }
}
