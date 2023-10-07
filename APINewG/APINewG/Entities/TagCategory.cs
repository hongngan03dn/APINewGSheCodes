using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class TagCategory
    {
        public TagCategory()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
