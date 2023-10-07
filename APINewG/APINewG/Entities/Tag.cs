using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class Tag
    {
        public int Id { get; set; }
        public int? IdTagCategory { get; set; }
        public string? Name { get; set; }

        public virtual TagCategory? IdTagCategoryNavigation { get; set; }
    }
}
