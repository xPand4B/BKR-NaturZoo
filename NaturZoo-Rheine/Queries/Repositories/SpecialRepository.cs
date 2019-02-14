using System;
using System.Data;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Queries.Core.Repositories;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A <see cref="SpecialRepository"/> repository for working with data in the database.
    /// </summary>
    class SpecialRepository
    {
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public SpecialRepository(Database.Database context)
        {
            _context = context ?? throw new ArgumentNullException("context");
        }

        public DataTable Aufgabe01()
        {
            return _context.Query(
                "SELECT animal.name as Name, animal.gender as Geschlecht, animal.species as Art, foodplan.time as Zeit, foodplan.weekday as Wochentag, food.name as Futter " +
                "FROM animal, foodplan, food " +
                "WHERE foodplan.fk_animalid = animal.id " +
                    "AND foodplan.fk_foodid = food.id " +
                    "AND time='09:00'"
            );
        }

        public DataTable Aufgabe02()
        {
            return null;
        }

        public DataTable Aufgabe03(String enclosureID)
        {
            return _context.Query(string.Format(
                "SELECT count(*) as 'Anzahl Tiere' " +
                "FROM animal, enclosure " +
                "WHERE animal.fk_enclosureid = enclosure.id " +
                    "AND animal.fk_enclosureid = {0}",
                enclosureID
            ));
        }

        public DataTable Aufgabe04(String enclosureID)
        {
            return _context.Query(
                ""
            );
        }

        public DataTable Aufgabe05(String guardianID)
        {
            return _context.Query(string.Format(
                "SELECT animal.name as Tier, animal.gender as Geschlecht, animal.species as Art " +
                "FROM guardian, animal " +
                "WHERE guardian.fk_territoryid = animal.fk_territoryid " +
                    "AND guardian.id = {0}",
                guardianID
            ));
        }

        public DataTable Aufgabe06()
        {
            return _context.Query(
                "SELECT animal.name as Tier, animal.gender as Geschlecht, animal.species as Art " +
                "FROM animal " +
                    "LEFT JOIN foodplan " +
                        "on animal.id = foodplan.fk_animalid " +
                "WHERE foodplan.fk_animalid IS NULL"
            );
        }

        public DataTable Aufgabe07(String guardianID)
        {
            return _context.Query(string.Format(
                "SELECT enclosure.name as Gehege " +
                "FROM guardian, building, enclosure " +
                "WHERE guardian.fk_territoryid = building.fk_territoryid " +
                    "AND enclosure.fk_buildingid = building.id " +
                    "AND guardian.id = {0}",
                guardianID
            ));
        }

        public DataTable Aufgabe08()
        {
            return _context.Query(
                "SELECT foodplan.time as Zeit, foodplan.weekday as Wochentag, food.name as Futter, food.amount as 'Menge (in kg.)' " +
                "FROM foodplan, food, animal " +
                "WHERE foodplan.fk_animalid = animal.id " +
                    "AND foodplan.fk_foodid = food.id " +
                    "AND animal.name = 'Theo' " +
                    "AND animal.species = 'Tiger'"
            );
        }
    }
}
