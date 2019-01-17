using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="FoodRepository"/> repository for working with data in the database.
    /// </summary>
    class FoodRepository : GenericRepository<Food>
    {
        private readonly Food _food;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public FoodRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _food = new Food();
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        public override DataTable GetAll()
        {
            return base.GetAll(_food.Showable, _food.ForeignTable);
        }
    }
}
