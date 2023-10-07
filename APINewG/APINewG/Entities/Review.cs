using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class Review
    {
        public Review()
        {
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public int? IdConnection { get; set; }
        public string? ContentRef { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public virtual Connection? IdConnectionNavigation { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
