using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="FoodplanRepository"/> repository for working with data in the database.
    /// </summary>
    class FoodplanRepository : GenericRepository<Foodplan>
    {
        private readonly Foodplan _foodplan;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodplanRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public FoodplanRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _foodplan = new Foodplan();
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        public override DataTable GetAll()
        {
            return base.GetAll(_foodplan.Showable, _foodplan.ForeignTable);
        }
    }
}
