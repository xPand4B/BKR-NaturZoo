using System;
using System.Collections.Generic;
using System.Data;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Queries.Repositories
{
    /// <summary>
    /// A Zoo repository for calling other repos for working with data in the database.
    /// </summary>
    class ZooRepository
    {
        private readonly AnimalRepository animalRepository;
        private readonly BuildingRepository buildingRepository;
        private readonly EnclosureRepository enclosureRepository;
        private readonly GuardianRepository guardianRepository;
        private readonly LogRepository logRepository;
        private readonly SupplierRepository supplierRepository;
        private readonly TerritoryRepository territoryRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="ZooRepository"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public ZooRepository(Database.Database context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            // Repository initialization
            animalRepository    = new AnimalRepository(context);
            buildingRepository  = new BuildingRepository(context);
            enclosureRepository = new EnclosureRepository(context);
            guardianRepository  = new GuardianRepository(context);
            logRepository       = new LogRepository(context);
            supplierRepository  = new SupplierRepository(context);
            territoryRepository = new TerritoryRepository(context);
        }


        #region Animal
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Animal"/> entity.
        /// </summary>
        public String GetAnimalCount {
            get { return animalRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Animal"/> entity.
        /// </summary>
        public DataTable GetAnimalGrid {
            get { return animalRepository.GetAll(); }
        }

        /// <summary>
        /// Creates a <see cref="Animal"/> entity.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="animal"/> is null</exception>
        public void CreateAnimal(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("animal");

            animalRepository.Add(animal);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetAnimalLastChange {
            get { return animalRepository.LastUpdate(); }
        }
        #endregion


        #region Building
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Building"/> entity.
        /// </summary>
        public String GetBuildingCount {
            get { return buildingRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Building"/> entity.
        /// </summary>
        public DataTable GetBuildingGrid {
            get { return buildingRepository.GetAll(); }
        }

        /// <summary>
        /// Get building dropdown data.
        /// </summary>
        public DataTable GetBuildingDropdown {
            get { return buildingRepository.GetDropdown(); }
        }

        /// <summary>
        /// Creates a <see cref="Building"/> entity.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="building"/> is null</exception>
        public void CreateBuilding(Building building)
        {
            if (building == null)
                throw new ArgumentNullException("building");

            buildingRepository.Add(building);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetBuildingLastChange {
            get { return buildingRepository.LastUpdate(); }
        }
        #endregion


        #region Enclosure
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Enclosure"/> entity.
        /// </summary>
        public String GetEnclosureCount {
            get { return enclosureRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Enclosure"/> entity.
        /// </summary>
        public DataTable GetEnclosureGrid {
            get { return enclosureRepository.GetAll(); }
        }

        /// <summary>
        /// Get enclosure dropdown data.
        /// </summary>
        public DataTable GetEnclosureDropdown {
            get { return enclosureRepository.GetDropdown(); }
        }

        /// <summary>
        /// Creates a <see cref="Enclosure"/> entity.
        /// </summary>
        /// <param name="animal"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="enclosure"/> is null</exception>
        public void CreateEnclosure(Enclosure enclosure)
        {
            if (enclosure == null)
                throw new ArgumentNullException("enclosure");

            enclosureRepository.Add(enclosure);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetEnclosureLastChange {
            get { return enclosureRepository.LastUpdate(); }
        }
        #endregion


        #region Guardian
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Guardian"/> entity.
        /// </summary>
        public String GetGuardianCount
        {
            get { return guardianRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Guardian"/> entity.
        /// </summary>
        public DataTable GetGuardianGrid {
            get { return guardianRepository.GetAll(); }
        }

        /// <summary>
        /// Creates a <see cref="Guardian"/> entity.
        /// </summary>
        /// <param name="guardian"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void CreateGuardian(Guardian guardian)
        {
            if(guardian == null)
                throw new ArgumentNullException("guardian");

            guardianRepository.Add(guardian);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetGuardianLastChange {
            get { return guardianRepository.LastUpdate(); }
        }
        #endregion


        #region Log
        /// <summary>
        /// Get all <see cref="Log"/> entries.
        /// </summary>
        public List<string> GetLog {
            get { return logRepository.GetLog(); }
        }
        #endregion


        #region Supplier
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Supplier"/> entity.
        /// </summary>
        public String GetSupplierCount {
            get { return supplierRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Supplier"/> entity.
        /// </summary>
        public DataTable GetSupplierGrid {
            get { return supplierRepository.GetAll(); }
        }

        /// <summary>
        /// Creates a <see cref="Supplier"/> entity.
        /// </summary>
        /// <param name="supplier"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void CreateSupplier(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException("supplier");

            supplierRepository.Add(supplier);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetSupplierLastChange {
            get { return supplierRepository.LastUpdate(); }
        }
        #endregion


        #region Territory
        /// <summary>
        /// Get a count <seealso cref="String"/> from the <see cref="Territory"/> entity.
        /// </summary>
        public String GetTerritoryCount {
            get { return territoryRepository.Count(); }
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the <see cref="Territory"/> entity.
        /// </summary>
        public DataTable GetTerritoryGrid {
            get { return territoryRepository.GetAll(); }
        }

        /// <summary>
        /// Get territory dropdown data.
        /// </summary>
        public DataTable GetTerritoryDropdown
        {
            get { return territoryRepository.GetDropdown(); }
        }

        /// <summary>
        /// Creates a <see cref="Territory"/> entity.
        /// </summary>
        /// <param name="territory"></param>
        /// <exception cref="ArgumentNullException"> if <paramref name="territory"/> is null</exception>
        public void CreateTerritory(Territory territory)
        {
            if (territory == null)
                throw new ArgumentNullException("territory");

            territoryRepository.Add(territory);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String GetTerritoryLastChange {
            get { return territoryRepository.LastUpdate(); }
        }
        #endregion
    }
}
