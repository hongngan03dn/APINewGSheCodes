using APINewG.Entities;
using APINewG.Models;

namespace APINewG.Repositories
{
    public interface ITagRepository
    {
        public Task<List<TagCategoryModel>> GetAllTagsAndCategories();
        public Task SaveTagsToIdUser(int IdUser, List<int> IdTags);
    }
}
