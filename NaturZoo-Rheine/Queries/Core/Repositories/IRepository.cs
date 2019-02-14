using System;
using System.Collections.Generic;
using System.Data;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Queries.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        void Add(TEntity entity);

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        DataTable GetAll();

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">Showable fields.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        DataTable GetAll(List<string> showable);

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">Showable fields.</param>
        /// <param name="foreignTable">Showable fields.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="foreignTable"/> is null</exception>
        DataTable GetAll(List<string> showable, List<string> foreignTable);

        /// <summary>
        /// Update data for the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        void Update(TEntity entity);

        /// <summary>
        /// Get a count <seealso cref="String"/> from the specified entity.
        /// </summary>
        String Count();

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        String LastUpdate();

        /// <summary>
        /// Get dropdown items.
        /// </summary>
        DataTable GetDropdown();
    }
}
