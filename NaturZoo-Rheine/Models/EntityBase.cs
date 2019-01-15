using System;
using System.Collections.Generic;

namespace NaturZoo_Rheine.Models
{
    /// <summary>
    /// Provides a base for every database model/entity.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// The Entity id.
        /// </summary>
        public Int32 Id { get; protected set; }

        /// <summary>
        /// The created_at timestamp.
        /// </summary>
        public DateTime created_at { get; protected set; }

        /// <summary>
        /// The updated_at timestamp.
        /// </summary>
        public DateTime updated_at { get; protected set; }

        /// <summary>
        /// All showable fields for the output.
        /// </summary>
        protected List<string> showable = new List<string>();

        /// <summary>
        /// Get all showable fields for the output.
        /// </summary>
        public List<string> Showable { get { return showable; } }

        /// <summary>
        /// The relationshiop to another table.
        /// </summary>
        protected List<string> foreignTable = new List<string>();

        /// <summary>
        /// Get the relationship to another table.
        /// </summary>
        public List<string> ForeignTable { get { return foreignTable; } }
    }
}
