using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="BuildingRepository"/> repository for working with data in the database.
    /// </summary>
    class BuildingRepository : GenericRepository<Building>
    {
        private readonly Building _building;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public BuildingRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _building = new Building();
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        public override DataTable GetAll()
        {
            return base.GetAll(_building.Showable, _building.ForeignTable);
        }
    }
}
