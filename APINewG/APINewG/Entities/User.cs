using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class User
    {
        public User()
        {
            ConnectionIdLocalNavigations = new HashSet<Connection>();
            ConnectionIdTouristNavigations = new HashSet<Connection>();
        }

        public int Id { get; set; }
        public int? IdRole { get; set; }
        public int? IdAvatarFile { get; set; }
        public string? Name { get; set; }
        public DateTime? Bod { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Introduction { get; set; }
        public string? Tags { get; set; }
        public string? Language { get; set; }
        public string? Cccd { get; set; }

        public virtual File? IdAvatarFileNavigation { get; set; }
        public virtual Role? IdRoleNavigation { get; set; }
        public virtual ICollection<Connection> ConnectionIdLocalNavigations { get; set; }
        public virtual ICollection<Connection> ConnectionIdTouristNavigations { get; set; }
    }
}
