using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturZoo_Rheine.View
{
    public partial class UpdateForm<TEntity> : MetroFramework.Forms.MetroForm
    {
        private TEntity _entity;
        private readonly NaturZoo_Rheine.Database.Database _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateForm{TEntity}"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public UpdateForm(Database.Database context, TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");

            _entity  = entity;
            _context = context ?? throw new ArgumentNullException("context");
            
            InitializeComponent();
        }
    }
}
