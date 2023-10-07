using System;
using System.Collections.Generic;

namespace APINewG.Entities
{
    public partial class ConnectionStatus
    {
        public ConnectionStatus()
        {
            Connections = new HashSet<Connection>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Connection> Connections { get; set; }
    }
}
