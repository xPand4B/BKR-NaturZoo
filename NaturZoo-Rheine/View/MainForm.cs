using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NaturZoo_Rheine.Models;

namespace NaturZoo_Rheine.View {
    /// <summary>
    /// Provides the Main Form.
    /// </summary>
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private NaturZoo_Rheine.Queries.Repositories.ZooRepository Zoo;
        private readonly String _defaultPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"> if <paramref name="context"/> is null</exception>
        public MainForm(Database.Database context, Int32 permission, String defaultPassword)
        {
            InitializeComponent();

            if (context == null)
                throw new ArgumentNullException("context");

            _defaultPassword = defaultPassword;

            // Zoo initialization
            Zoo = new NaturZoo_Rheine.Queries.Repositories.ZooRepository(context);

            // Set start values
            this.tabControlMain_Selected(this, null);

            // Load all Data
            RefreshGuardian();
            RefreshTerritory();
            RefreshBuilding();
            RefreshEnclosure();
            RefreshAnimal();
            RefreshSupplier();
            RefreshFood();
            RefreshFoodplan();
        }


        /// <summary>
        /// Change password.
        /// </summary>
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon", "System Information", MessageBoxButtons.OK);
        }


        #region tabControl Main
        /// <summary>
        /// <para>Main TabControl</para>
        /// Set the default view data for the selected tab.
        /// </summary>
        private void tabControlMain_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControlMain.SelectedTab.Name) {
                case "tabÜbersicht":
                    //
                    break;

                case "tabPfleger":
                    this.tabControlPfleger.SelectedIndex = 0;
                    break;

                case "tabReviere":
                    this.tabControlReviere.SelectedIndex = 0;
                    break;

                case "tabGebäude":
                    this.tabControlGebäude.SelectedIndex = 0;
                    break;

                case "tabGehege":
                    this.tabControlGehege.SelectedIndex = 0;
                    break;

                case "tabTiere":
                    this.tabControlTiere.SelectedIndex = 0;
                    break;

                case "tabLieferanten":
                    this.tabControlLieferanten.SelectedIndex = 0;
                    break;

                case "tabFütterung":
                    //
                    break;

                case "tabLog":
                    listBoxLog.DataSource = Zoo.GetLog;
                    break;

                case "tabSuchen":
                    //
                    break;

                default:
                    break;
            }
        }
        #endregion


        #region tabControl Pfleger
        /// <summary>
        /// Refresh Guardian Data
        /// </summary>
        private void RefreshGuardian()
        {
            // Guardian Card
            labelÜbersichtPfleger_Count.Text           = Zoo.GetGuardianCount;
            labelÜbersichtPflegerLastChange_Value.Text = Zoo.GetGuardianLastChange;
            // Guardian Tab
            labelPflegerAlle_Count.Text = Zoo.GetGuardianCount;
            gridPflegerAlle.DataSource  = Zoo.GetGuardianGrid;
        }

        /// <summary>
        /// <para>Guardian Tab</para>
        /// Text Change
        /// </summary>
        private void PflegerInput_TextChanged(object sender, EventArgs e)
        {
            if (textPflegerAdd_Name.Text == ""
               || textPflegerAdd_Surname.Text == ""
               || textPflegerAdd_Email.Text == ""
               //|| textPflegerAdd_Password.Text == ""
               || comboPflegerAdd_PLZ.Text == ""
               || comboPflegerAdd_Stadt.Text == ""
               || textPflegerAdd_Street.Text == ""
               || textPflegerAdd_Phone.Text == ""
               || comboPflegerAdd_Revier.Text == ""
               //|| comboPflegerAdd_Permission.Text == ""
               ) {
                buttonPflegerAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonPflegerAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Guardian Tab</para>
        /// Adds a <see cref="Guardian"/>.
        /// </summary>
        private void buttonPflegerAdd_Add_Click(object sender, EventArgs e)
        {
            if (buttonPflegerAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                Zoo.CreateGuardian(new Guardian {
                    Name           = textPflegerAdd_Name.Text,
                    Surname        = textPflegerAdd_Surname.Text,
                    Email          = textPflegerAdd_Email.Text,
                    Password       = _defaultPassword,
                    fk_addressID   = 1,
                    Street         = textPflegerAdd_Street.Text,
                    Telephone      = textPflegerAdd_Phone.Text,
                    Birthday       = Convert.ToDateTime(dateTimePflegerAdd_Birthday.Value).ToString("yyyy-MM-dd").ToString(),
                    fk_territoryID = (int)comboPflegerAdd_Revier.SelectedValue,
                    Permission     = 1
                });

                textPflegerAdd_Name.Text = string.Empty;
                textPflegerAdd_Surname.Text = string.Empty;
                textPflegerAdd_Email.Text = string.Empty;
                //textPflegerAdd_Password.Text = string.Empty;
                comboPflegerAdd_PLZ.Text = string.Empty;
                comboPflegerAdd_Stadt.Text = string.Empty;
                textPflegerAdd_Street.Text = string.Empty;
                textPflegerAdd_Phone.Text = string.Empty;
                comboPflegerAdd_Revier.SelectedIndex = -1;
                //comboPflegerAdd_Permission.SelectedIndex = -1;

                MessageBox.Show("Pfleger wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshGuardian();
            }
        }
        #endregion


        #region tabControl Reviere
        /// <summary>
        /// Refresh Territory Data.
        /// </summary>
        private void RefreshTerritory()
        {
            // Territory Card
            labelÜbersichtReviere_Count.Text       = Zoo.GetTerritoryCount;
            labelÜbersichtReviere_LastChanged.Text = Zoo.GetTerritoryLastChange;
            // Territory Tab
            labelReviereAlle_Count.Text = Zoo.GetTerritoryCount;
            gridReviereAlle.DataSource  = Zoo.GetTerritoryGrid;
            // Guardian Tab
            comboPflegerAdd_Revier.DataSource = Zoo.GetTerritoryDropdown;
            comboPflegerAdd_Revier.DisplayMember = "name";
            comboPflegerAdd_Revier.ValueMember = "Id";
            comboPflegerAdd_Revier.SelectedIndex = -1;
            // Building Tab
            comboGebäudeAdd_Revier.DataSource = Zoo.GetTerritoryDropdown;
            comboGebäudeAdd_Revier.DisplayMember = "name";
            comboGebäudeAdd_Revier.ValueMember = "Id";
            comboGebäudeAdd_Revier.SelectedIndex = -1;
            // Animal Tab
            comboTiereAdd_Revier.DataSource = Zoo.GetTerritoryDropdown;
            comboTiereAdd_Revier.DisplayMember = "name";
            comboTiereAdd_Revier.ValueMember = "Id";
            comboTiereAdd_Revier.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Reviere Tab</para>
        /// Text Change
        /// </summary>
        private void ReviereInput_TextChanged(object sender, EventArgs e)
        {
            if (textReviereAdd_Name.Text == "") {
                buttonReviereAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonReviereAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Territory Tab</para>
        /// Adds a <see cref="Territory"/>.
        /// </summary>
        private void buttonReviereAdd_Add_Click(object sender, EventArgs e)
        {
            if (buttonReviereAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                Zoo.CreateTerritory(new Territory {
                    Name = textReviereAdd_Name.Text
                });

                textReviereAdd_Name.Text = string.Empty;

                MessageBox.Show("Revier wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshTerritory();
            }
        }
        #endregion


        #region tabControl Gebäude
        /// <summary>
        /// Refresh Building Data.
        /// </summary>
        private void RefreshBuilding()
        {
            // Building Card
            labelÜbersichtGebäude_Count.Text       = Zoo.GetBuildingCount;
            labelÜbersichtGebäude_LastChanged.Text = Zoo.GetBuildingLastChange;
            // Building Tab
            labelGebäudeAlle_Count.Text = Zoo.GetBuildingCount;
            gridGebäudeAlle.DataSource  = Zoo.GetBuildingGrid;
            // Enslosure Tab
            comboGehegeAdd_Gebäude.DataSource = Zoo.GetBuildingDropdown;
            comboGehegeAdd_Gebäude.DisplayMember = "name";
            comboGehegeAdd_Gebäude.ValueMember = "Id";
            comboGehegeAdd_Gebäude.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Gebäude Tab</para>
        /// Text Change
        /// </summary>
        private void GebäudeInput_TextChanged(object sender, EventArgs e)
        {
            if (textGebäudeAdd_Name.Text == ""
                || comboGebäudeAdd_Revier.Text == ""
                ) {
                buttonGebäudeAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonGebäudeAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Gebäude Tab</para>
        /// Adds a <see cref="Building"/>.
        /// </summary>
        private void buttonGebäudeAdd_Add_Click(object sender, EventArgs e)
        {
            if (buttonGebäudeAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                MessageBox.Show(comboGebäudeAdd_Revier.SelectedValue.ToString());

                Zoo.CreateBuilding(new Building {
                    Name           = textGebäudeAdd_Name.Text,
                    fk_territoryID = (int)comboGebäudeAdd_Revier.SelectedValue
                });

                textGebäudeAdd_Name.Text = string.Empty;
                comboGebäudeAdd_Revier.SelectedIndex = -1;

                MessageBox.Show("Gebäude wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshBuilding();
            }
        }
        #endregion


        #region tabControl Gehege
        /// <summary>
        /// Refresh Enclosure Data.
        /// </summary>
        private void RefreshEnclosure()
        {
            // Enclosure Card
            labelÜbersichtGehege_Count.Text       = Zoo.GetEnclosureCount;
            labelÜbersichtGehege_LastChanged.Text = Zoo.GetEnclosureLastChange;
            // Enclosure Tab
            labelGehegeAlle_Count.Text = Zoo.GetEnclosureCount;
            gridGehegeAlle.DataSource  = Zoo.GetEnclosureGrid;
            // Animal Tab
            comboTiereAdd_Gehege.DataSource = Zoo.GetEnclosureDropdown;
            comboTiereAdd_Gehege.DisplayMember = "name";
            comboTiereAdd_Gehege.ValueMember = "Id";
            comboTiereAdd_Gehege.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Gehege Tab</para>
        /// Text Change
        /// </summary>
        private void GehegeInput_TextChanged(object sender, EventArgs e)
        {
            if (textGehegeAdd_Name.Text == ""
                || comboGehegeAdd_Gebäude.Text == ""
                ) {
                buttonGehegeAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonGehegeAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Gehege Tab</para>
        /// Adds a <see cref="Enclosure"/>.
        /// </summary>
        private void buttonGehegeAdd_Add_Click(object sender, EventArgs e)
        {
            if (buttonGehegeAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                Zoo.CreateEnclosure(new Enclosure {
                    Name          = textGehegeAdd_Name.Text,
                    fk_buildingID = comboGehegeAdd_Gebäude.SelectedIndex
                });

                textGehegeAdd_Name.Text = string.Empty;
                comboGehegeAdd_Gebäude.SelectedIndex = -1;

                MessageBox.Show("Gehege wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshEnclosure();
            }
        }
        #endregion


        #region tabControl Tiere
        /// <summary>
        /// Refresh animal data
        /// </summary>
        private void RefreshAnimal()
        {
            // Animal Card
            labelÜbersichtTiere_Count.Text           = Zoo.GetAnimalCount;
            labelÜbersichtTiereLastChange_Value.Text = Zoo.GetAnimalLastChange;
            // Animal Tab
            labelTiereAlle_Count.Text = Zoo.GetAnimalCount;
            gridTiereAlle.DataSource  = Zoo.GetAnimalGrid;
            // Foodplan Tab
            comboFütterungAdd_Animal.DataSource = Zoo.GetAnimalDropdown;
            comboFütterungAdd_Animal.DisplayMember = "name";
            comboFütterungAdd_Animal.ValueMember = "Id";
            comboFütterungAdd_Animal.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Guardian Tab</para>
        /// Text Change
        /// </summary>
        private void TierInput_TextChanged(object sender, EventArgs e)
        {
            if (textTiereAdd_Name.Text == ""
                || comboTiereAdd_Species.Text == ""
                || textTiereAdd_Gender.Text == ""
                || comboTiereAdd_Revier.Text == ""
                || comboTiereAdd_Gehege.Text == ""
                ) {
                buttonTiereAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonTiereAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Animal Tab</para>
        /// Adds a <see cref="Animal"/>.
        /// </summary>
        private void buttonTiereAdd_Add_Click(object sender, EventArgs e)
        {
            if (buttonTiereAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                Zoo.CreateAnimal(new Animal {
                    Name            = textTiereAdd_Name.Text,
                    Species         = comboTiereAdd_Species.Text,
                    Gender          = textTiereAdd_Gender.Text,
                    Birthday        = Convert.ToDateTime(dateTimeTiereAdd_Birthday.Value).ToString("yyyy-MM-dd").ToString(),
                    fk_territoryID  = (int)comboTiereAdd_Revier.SelectedValue,
                    fk_enclosureID  = (int)comboTiereAdd_Gehege.SelectedValue,
                    away_since      = null
                });

                textTiereAdd_Name.Text = string.Empty;
                comboTiereAdd_Species.Text = string.Empty;
                textTiereAdd_Gender.Text = string.Empty;
                comboTiereAdd_Revier.SelectedIndex = -1;
                comboTiereAdd_Gehege.SelectedIndex = -1;

                MessageBox.Show("Tier wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshAnimal();
            }
        }
        #endregion


        #region tabControl Lieferanten
        /// <summary>
        /// Refresh supplier data
        /// </summary>
        private void RefreshSupplier()
        {
            // Suplier Card
            labelÜbersichtLieferanten_Count.Text           = Zoo.GetSupplierCount;
            labelÜbersichtLieferantenLastChange_Value.Text = Zoo.GetSupplierLastChange;
            // Supplier Tab
            labelLieferantenAlle_Count.Text = Zoo.GetSupplierCount;
            gridLieferantenAlle.DataSource  = Zoo.GetSupplierGrid;
            // Food Tab
            comboFutterAdd_Lieferant.DataSource = Zoo.GetSupplierDropdown;
            comboFutterAdd_Lieferant.DisplayMember = "name";
            comboFutterAdd_Lieferant.ValueMember = "Id";
            comboFutterAdd_Lieferant.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Lieferanten Tab</para>
        /// Text Change
        /// </summary>
        private void LieferantenInput_TextChanged(object sender, EventArgs e)
        {
            if (textLieferantenAdd_Name.Text == ""
                || comboLieferantenAdd_PLZ.Text == ""
                || comboLieferantenAdd_Stadt.Text == ""
                || textLieferantenAdd_Street.Text == ""
                || textLieferantenAdd_Phone.Text == ""
                || textLieferantenAdd_ContactSurname.Text == ""
                || textLieferantenAdd_ContactName.Text == ""
                ) {
                buttonLieferantenAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            } else {
                buttonLieferantenAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Supplier Tab</para>
        /// Adds a <see cref="Supplier"/>.
        /// </summary>
        private void buttonLieferantenAdd_add_Click(object sender, EventArgs e)
        {
            if (buttonLieferantenAdd_Add.BackColor == Color.FromArgb(158, 158, 158)) {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            } else {
                Zoo.CreateSupplier(new Supplier {
                    Name                    = textLieferantenAdd_Name.Text,
                    fk_addressID            = 1,
                    Street                  = textLieferantenAdd_Street.Text,
                    telephone               = textLieferantenAdd_Phone.Text,
                    Contact_Person_Name     = textLieferantenAdd_ContactSurname.Text,
                    Contact_Person_Surname  = textLieferantenAdd_ContactName.Text
                });

                textLieferantenAdd_Name.Text = string.Empty;
                comboLieferantenAdd_PLZ.Text = string.Empty;
                comboLieferantenAdd_Stadt.Text = string.Empty;
                textLieferantenAdd_Street.Text = string.Empty;
                textLieferantenAdd_Phone.Text = string.Empty;
                textLieferantenAdd_ContactSurname.Text = string.Empty;
                textLieferantenAdd_ContactName.Text = string.Empty;

                MessageBox.Show("Lieferant wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshSupplier();
            }
        }
        #endregion


        #region tabControl Futter
        /// <summary>
        /// Refresh food data
        /// </summary>
        private void RefreshFood()
        {
            // Food Card
            labelÜbersichtFutter_Count.Text             = Zoo.GetFoodCount;
            labelÜbersichtFutterLastChanged_Value.Text  = Zoo.GetFoodLastChange;
            // Food Tab
            labelFutterAlle_Count.Text  = Zoo.GetFoodCount;
            gridFutterAlle.DataSource   = Zoo.GetFoodGrid;
            // Foodplan Tab
            comboFütterungAdd_Food.DataSource = Zoo.GetFoodDropdown;
            comboFütterungAdd_Food.DisplayMember = "name";
            comboFütterungAdd_Food.ValueMember = "Id";
            comboFütterungAdd_Food.SelectedIndex = -1;
        }

        /// <summary>
        /// <para>Futter Tab</para>
        /// Text Change
        /// </summary>
        private void FutterInput_TextChanged(object sender, EventArgs e)
        {
            if(textFutterAdd_Name.Text == ""
                || comboFutterAdd_Lieferant.Text == ""
                ){
                buttonFutterAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            }
            else
            {
                buttonFutterAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Futter Tab</para>
        /// Adds <see cref="Food"/>.
        /// </summary>
        private void buttonFutterAdd_Add_Click(object sender, EventArgs e)
        {
            if(buttonFutterAdd_Add.BackColor == Color.FromArgb(158, 158, 158))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            }
            else
            {
                Zoo.CreateFood(new Food {
                    Name = textFutterAdd_Name.Text,
                    Amount = (int)numericFutterAdd_Amount.Value,
                    fk_supplierID = (int)comboFutterAdd_Lieferant.SelectedValue,
                });

                textFutterAdd_Name.Text = string.Empty;
                numericFutterAdd_Amount.Value = 1;
                comboFutterAdd_Lieferant.SelectedIndex = -1;

                MessageBox.Show("Futter wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);

                RefreshFood();
            }
        }
        #endregion


        #region tabControl Fütterung
        /// <summary>
        /// Refresh foodplan data
        /// </summary>
        private void RefreshFoodplan()
        {
            // Foodplan Card
            labelÜbersichtFütterung_Count.Text = Zoo.GetFoodplanCount;
            labelÜbersichtFütterungLastChanged_Value.Text = Zoo.GetFoodplanLastChange;

            // Foodplan Tab
            labelFütterungAlle_Count.Text = Zoo.GetFoodplanCount;
            gridFütterungAlle.DataSource = Zoo.GetFoodplanGrid;
        }

        /// <summary>
        /// <para>Fütterung Tab</para>
        /// Text Change
        /// </summary>
        private void FütterungInput_TextChanged(object sender, EventArgs e)
        {
            if(comboFütterungAdd_Animal.Text == ""
                || comboFütterungAdd_Food.Text == ""
                || textFütterungAdd_Weekday.Text == ""
                ){
                buttonFütterungAdd_Add.BackColor = Color.FromArgb(158, 158, 158);
            }
            else
            {
                buttonFütterungAdd_Add.BackColor = Color.FromArgb(0, 200, 83);
            }
        }

        /// <summary>
        /// <para>Fütterung Tab</para>
        /// Adds <see cref="Food"/>.
        /// </summary>
        private void buttonFütterungAdd_Add_Click(object sender, EventArgs e)
        {
            if(buttonFütterungAdd_Add.BackColor == Color.FromArgb(158, 158, 158))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen.", "Nutzer information", MessageBoxButtons.OK);
            }
            else
            {
                Zoo.CreateFoodplan(new Foodplan {
                    fk_animalID = (int)comboFütterungAdd_Animal.SelectedValue,
                    fk_foodID = (int)comboFütterungAdd_Food.SelectedValue,
                    Time = dateTimeFütterungAdd_Time.Value.ToString("HH:mm"),
                    Weekday = textFütterungAdd_Weekday.Text,
                    Amount = (int)numericFütterungAdd_Amount.Value
                });

                comboFütterungAdd_Animal.SelectedIndex = -1;
                comboFütterungAdd_Food.SelectedIndex = -1;
                textFütterungAdd_Weekday.Text = string.Empty;
                numericFütterungAdd_Amount.Value = 1;

                MessageBox.Show("Fütterung wurde hinzugefügt.", "Application update", MessageBoxButtons.OK);
                
                RefreshFoodplan();
            }
        }
        #endregion
    }
}
