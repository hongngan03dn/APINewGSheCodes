using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class File
    {
        public File()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? NameFile { get; set; }
        public string? Path { get; set; }
        public int? IdReview { get; set; }
        public int? Status { get; set; }

        public virtual Review? IdReviewNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
