using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.Queries.Core.Repositories
{
    /// <summary>
    /// A generic repository for working with data in the database.
    /// </summary>
    /// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private String _tableName;
        private readonly NaturZoo_Rheine.Database.Database _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public GenericRepository(Database.Database context)
        {
            _context = context ?? throw new ArgumentNullException("context");
            _tableName = typeof(TEntity).ToString().ToLower();

            String[] tmp = _tableName.Split('.');
            _tableName   = tmp[tmp.Length - 1];
        }


        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");


            List<string> fillable = new List<string>();
            List<string> values   = new List<string>();

            var bindingFlags = BindingFlags.Instance 
                             | BindingFlags.Public
                             | BindingFlags.Default;

            var fields = entity.GetType()
                               .GetProperties(bindingFlags)
                               .Where(value => value != null)
                               .ToList();

            
            for (int i = 0; i < fields.Count - 5; i++) {

                fillable.Add(fields[i].Name.ToLower());

                if (fields[i].GetType().IsEnum) {
                    values.Add(fields[i].GetValue(entity).ToString());

                } else {
                    try {
                        try {
                            values.Add((string)fields[i].GetValue(entity));

                        } catch {
                            values.Add(fields[i].GetValue(entity).ToString());
                        }
                    } catch {
                        values.Add(string.Empty);
                    }
                }
                //MessageBox.Show(fillable[i] + " '" + values[i] + "'");
            }

            _context.Add(_tableName, fillable, values);
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        public virtual DataTable GetAll()
        {
            return _context.GetAll(_tableName);
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">Showable fields.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        public DataTable GetAll(List<string> showable)
        {
            if(showable.Count == 0)
                throw new ArgumentNullException("showable");

            return _context.GetAll(showable, _tableName);
        }

        /// <summary>
        /// Get all data as <seealso cref="DataTable"/> for the specified entity.
        /// </summary>
        /// <param name="showable">Showable fields.</param>
        /// <param name="foreignTable">Showable fields.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="showable"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="foreignTable"/> is null</exception>
        public DataTable GetAll(List<string> showable, List<string> foreignTable)
        {
            if(showable.Count == 0)
                throw new ArgumentNullException("showable");

            if(foreignTable.Count == 0)
                throw new ArgumentNullException("foreignTable");

            return _context.GetAll(showable, _tableName, foreignTable);
        }

        /// <summary>
        /// Update data for the specified entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a count <seealso cref="String"/> from the specified entity.
        /// </summary>
        public String Count()
        {
            return _context.Count(_tableName);
        }

        /// <summary>
        /// Get a the last changed value.
        /// </summary>
        public String LastUpdate()
        {
            return _context.LastUpdate(_tableName);
        }

        /// <summary>
        /// Get dropdown items.
        /// </summary>
        public DataTable GetDropdown()
        {
            return _context.GetDropdown(_tableName);
        }
    }
}
