using System;
using System.Data;
using System.Collections.Generic;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="Log"/> repository for working with data in the database.
    /// </summary>
    public class LogRepository : GenericRepository<Log>
    {
        private Log _log;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public LogRepository(Database.Database context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _log = new Log();
        }

        /// <summary>
        /// Get all <see cref="Log"/> entries.
        /// </summary>
        public List<string> GetLog()
        {
            List<string> lines = new List<string>();

            foreach (DataRow row in this.GetAll().Rows) {
                // STATUS   :: 0000-00-00 00:00:00 :: MESSAGE
                lines.Add(row[1].ToString() + "\t :: " + row[3].ToString() + " :: " + row[2].ToString());
            }
            return lines;
        }
    }
}
