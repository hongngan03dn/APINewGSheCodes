using APINewG.Entities;
using APINewG.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data;

namespace APINewG.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly testpbldbContext _context;
        private readonly IMapper _mapper;

        public TagRepository(testpbldbContext context, IMapper mapper) 
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<TagCategoryModel>> GetAllTagsAndCategories()
        {
            var a = _context.TagCategories.Include(x => x.Tags)
                                                .Select(x => new TagCategoryModel()
                                                {
                                                    Id = x.Id,
                                                    Name = x.Name,
                                                    Tags = x.Tags.Select(t => new TagModel()
                                                    {
                                                        Id = t.Id,
                                                        Name = t.Name
                                                    }).ToList()
                                                }).ToList();
            return a;
        }

        public async Task SaveTagsToIdUser(int IdUser, List<int> IdTags)
        {
            var user = _context.Users.Find(IdUser);
            if (user != null)
            {
                user.Tags = JsonConvert.SerializeObject(IdTags);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return;
            }
            throw new Exception("User Not Found");
        }
    }
}
