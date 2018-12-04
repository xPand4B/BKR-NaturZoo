using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaturZoo_Rheine {
    public partial class formMain : MetroFramework.Forms.MetroForm {
        /**
         * @var ZooRheine Zoo
         **/
        private ZooRheine Zoo;

        /**
         * Constructor
         **/
        public formMain()
        {
            // Load Login Form
            formLogin Login = new formLogin();
            Login.ShowDialog();

            // Close if Login window has been closed as well
            if(Login.loginSuccess == false) {
                Environment.Exit(1);
            }

            InitializeComponent();

            Zoo = new ZooRheine();

            // Fill main start values
            //labelÜbersichtNext_Value.Text       = this.Futter.GetNextFütterung;
            //labelÜbersichtTiere_Value.Text      = this.Tiere.GetCount;
            labelÜbersichtPfleger_Value.Text    = Zoo.GetPflegerCount;

        }

        /**
         * Set default view data for selected tab
         * 
         * @param objext sender
         * @param TabControlEventArgs e
         * 
         * @return void
         **/
        private void tabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControlPfleger.SelectedTab.Name == "tabPflegerAlle") {
                // Set Pfleger count
                labelPflegerAlle_Value.Text = Zoo.GetPflegerCount;

                // Set datagrid data
                gridPflegerAlle.DataSource = Zoo.GetPflegerGrid;
            }
        }

        /**
         * Set view data depending on the selected tab
         * 
         * @param objext sender
         * @param TabControlEventArgs e
         * 
         * @return void
         **/
        private void tabControlPfleger_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControlPfleger.SelectedTab.Name == "tabPflegerAlle"){
                // Set Pfleger count
                labelPflegerAlle_Value.Text = Zoo.GetPflegerCount;
                // Set datagrid data
                gridPflegerAlle.DataSource = Zoo.GetPflegerGrid;
            }
        }

        /**
         * Close Application
         * 
         * @param object sender
         * @param EventArgs e
         * 
         * @return void
         **/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
