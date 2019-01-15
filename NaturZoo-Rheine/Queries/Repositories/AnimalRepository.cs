using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="AnimalRepository"/> repository for working with data in the database.
    /// </summary>
    public class AnimalRepository : GenericRepository<Animal>
    {
        private readonly Animal _animal;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardianRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public AnimalRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _animal = new Animal();
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        public override DataTable GetAll()
        {
            return base.GetAll(_animal.Showable, _animal.ForeignTable);
        }
    }
}
