using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class Connection
    {
        public Connection()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public int? IdTourist { get; set; }
        public int? IdLocal { get; set; }
        public int? IdConnectionStatus { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Status { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public virtual ConnectionStatus? IdConnectionStatusNavigation { get; set; }
        public virtual User? IdLocalNavigation { get; set; }
        public virtual User? IdTouristNavigation { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
