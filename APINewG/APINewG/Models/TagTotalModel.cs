namespace APINewG.Models
{
    public class TagTotalModel
    {
        public TagCategoryModel question { get; set; }
        public List<TagModel> listAnswers { get; set; } = new List<TagModel>();
    }
}
