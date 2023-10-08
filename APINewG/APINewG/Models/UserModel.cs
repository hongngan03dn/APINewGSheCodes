namespace APINewG.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public int? IdRole { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Introduction { get; set; }
        public string? TagIdsString { get; set; }
        public List<TagModel> Tags { get; set; } = new List<TagModel>();
        public int? orderNum { get; set; }
    }
}
