using System;
using System.Collections.Generic;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides a base for every database model/entity.
    /// </summary>
    public abstract class EntityBase
    {
        public Int32 Id { get; protected set; }

        public DateTime created_at { get; protected set; }

        public DateTime updated_at { get; protected set; }

        protected List<string> showable = new List<string>();

        public List<string> Showable { get { return showable; } }
    }
}
