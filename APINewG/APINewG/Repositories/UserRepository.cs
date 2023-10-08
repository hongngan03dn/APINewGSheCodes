using APINewG.Entities;
using APINewG.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace APINewG.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly testpbldbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(testpbldbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<UserModel>> GetNearestRoadmates(int IdUser)
        {
            var user = _context.Users.Find(IdUser);
            if (user != null)
            {
                var result = _context.Users.Where(x => x.City ==  user.City && x.IdRole != user.IdRole)
                                            .Select(x => new UserModel()
                                            {
                                                Id = x.Id,
                                                City = x.City,
                                                Name = x.Name,
                                                IdRole = x.IdRole,
                                                Introduction = x.Introduction,
                                                TagIdsString = x.Tags,
                                                //Tags = getTagsByIds(JsonConvert.DeserializeObject<List<int>>(x.Tags))
                                            }).ToList();
                foreach (var item in result)
                {
                    item.Tags = getTagsByIds(JsonConvert.DeserializeObject<List<int>>(item.TagIdsString));
                }
                return result;
            }
            throw new Exception("User not found");
        }
        public List<TagModel> getTagsByIds(List<int> listId)
        {
            var result = _context.Tags.Where(x => listId.Contains(x.Id))
                                        .Select(x => new TagModel()
                                        {
                                            Id = x.Id,
                                            IdTagCategory = x.IdTagCategory,
                                            Name = x.Name,
                                        }).ToList();
            return result;
        }

        public async Task<List<UserModel>> GetSuggestedRoadmates(int IdUser)
        {
            var user = _context.Users.Find(IdUser);
            List<int> listIdTag = JsonConvert.DeserializeObject<List<int>>(user.Tags);
            if (user != null)
            {
                var result = _context.Users.Where(x => x.City == user.City && x.IdRole != user.IdRole)
                                            .Select(x => new UserModel()
                                            {
                                                Id = x.Id,
                                                City = x.City,
                                                Name = x.Name,
                                                IdRole = x.IdRole,
                                                Introduction = x.Introduction,
                                                TagIdsString = x.Tags,
                                            }).ToList();
                foreach (var item in result)
                {
                    List<int> listIdItem = JsonConvert.DeserializeObject<List<int>>(item.TagIdsString);
                    int order = 0;
                    foreach (var id in listIdTag)
                    {
                        if (!listIdItem.Contains(id))
                        {
                            listIdItem.Remove(id);
                            continue;
                        }
                        order++;
                    }
                    item.orderNum = order;
                    item.Tags = getTagsByIds(listIdItem);

                }
                return result.OrderByDescending(x => x.orderNum).ToList();
            }
            throw new Exception("User not found");
        }
    }
}
