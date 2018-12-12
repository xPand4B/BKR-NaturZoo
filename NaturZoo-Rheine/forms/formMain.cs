using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturZoo_Rheine.src;

namespace NaturZoo_Rheine {
    /// <summary>
    ///     Provides the Main Form.
    /// </summary>
    public partial class formMain : MetroFramework.Forms.MetroForm
    {
        private ZooRheine Zoo;


        /// <summary>
        ///     Initializes a new instance of the <see cref="formMain"/> class.
        /// </summary>
        public formMain()
        {
            // Load Login Form
            //var Login = new formLogin();
            //Login.ShowDialog();

            // Close if Login window has been closed without completing the login
            //if(Login.loginSuccess == false) { Environment.Exit(1); }

            InitializeComponent();
            Zoo = new ZooRheine();

            // Fill main start values
            //labelÜbersichtNext_Value.Text       = ;
            //labelÜbersichtTiere_Value.Text      = ;
            labelÜbersichtPfleger_Value.Text    = Zoo.GetGuardianCount;
        }
        

        /// <summary>
        ///     Set the default view data for the selected tab.
        /// </summary>
        private void tabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControlMain.SelectedTab.Name) {
                case "tabÜbersicht":
                    // Fill main start values
                    labelÜbersichtPfleger_Value.Text = Zoo.GetGuardianCount;
                    break;

                case "tabPfleger":
                    // Get Guardian Data
                    labelPflegerAlle_Value.Text = Zoo.GetManagementCount;
                    gridPflegerAlle.DataSource = Zoo.GetManagementGrid;
                    break;

                case "tabGehege":
                    MessageBox.Show("Gehege", "Coming soon");
                    break;

                case "tabTiere":
                    MessageBox.Show("Tiere", "Coming soon");
                    break;

                case "tabLieferanten":
                    MessageBox.Show("Lieferanten", "Coming soon");
                    break;

                case "tabFütterung":
                    MessageBox.Show("Fütterung", "Coming soon");
                    break;

                case "tabSuchen":
                    MessageBox.Show("Suche", "Coming soon");
                    break;

                default:
                    break;
            }
        }

        /**
         * Guardian Tab
         * Set view data depending on the selected tab
         * 
         * @param objext sender
         * @param TabControlEventArgs e
         * @return void
         **/

        /// <summary>
        ///     <para>Guardian Tab</para>
        ///     Set the view data depending on the selected tab.
        /// </summary>
        private void tabControlPfleger_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControlPfleger.SelectedTab.Name) {
                case "tabPflegerAlle":
                    // Get Guardian Data
                    labelPflegerAlle_Value.Text = Zoo.GetGuardianCount;
                    gridPflegerAlle.DataSource  = Zoo.GetGuardianGrid;
                    break;

                case "tabPflegerHinzufügen":
                    MessageBox.Show("Pfleger hinzufügen", "Coming soon");
                    break;

                default:
                    break;
            }
        }
        
        /// <summary>
        ///     Close the application.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
