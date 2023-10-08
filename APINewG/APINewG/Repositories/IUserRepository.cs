using APINewG.Models;

namespace APINewG.Repositories
{
    public interface IUserRepository
    {
        public Task<List<UserModel>> GetSuggestedRoadmates (int IdUser);
        public Task<List<UserModel>> GetNearestRoadmates(int IdUser);
    }
}
