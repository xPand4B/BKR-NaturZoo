using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturZoo_Rheine {
    class ZooRheine : Database
    {
        /**
         * Get Pfleger count
         * 
         * @return String result
         **/
        public String GetPflegerCount
        {
            get {
                return this.GetSingleValue(
                    "SELECT count(*) from management"
                );
            }
        }

        /**
         * Get Pfleger data for datagrid
         * 
         * @return Datatable results
         **/
        public DataTable GetPflegerGrid
        {
            get {
                return this.FillGridData("management",
                    "SELECT id" +
                    "FROM management"
                );
            }
        }
    }
}
