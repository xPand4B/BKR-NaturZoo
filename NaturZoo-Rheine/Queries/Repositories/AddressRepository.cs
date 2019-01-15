using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="Address"/> repository for working with data in the database.
    /// </summary>
    class AddressRepository : GenericRepository<Address>
    {
        private readonly Address _address;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public AddressRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _address = new Address();
        }
    }
}
