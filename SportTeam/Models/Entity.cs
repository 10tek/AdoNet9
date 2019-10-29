using System;
using System.Collections.Generic;
using System.Text;

namespace SportTeam.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
