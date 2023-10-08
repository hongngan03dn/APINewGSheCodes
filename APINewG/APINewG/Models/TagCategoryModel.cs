using APINewG.Entities;

namespace APINewG.Models
{
    public class TagCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
    }
}
