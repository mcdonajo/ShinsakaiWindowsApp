using System;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public partial class RegistrantEditor : Form
    {
        Registrant dialogRegistrant = null;

        public RegistrantEditor(ref Registrant reg)
        {
            InitializeComponent();
            Helper.populateListBoxOptions(divisionList);

            dialogRegistrant = reg;
            firstNameField.Text = reg.FirstName;
            lastNameField.Text = reg.LastName;
            dojoField.Text = reg.Dojo;
            foreach(Division div in reg.Divisions)
            {
                divisionList.SetSelected(divisionList.Items.IndexOf(div.ToString()), true);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!isValid())
            {
                return;
            }
            DialogResult = DialogResult.OK;
            dialogRegistrant.FirstName = firstNameField.Text;
            dialogRegistrant.LastName = lastNameField.Text;
            dialogRegistrant.Dojo = dojoField.Text;
            DataManager.RegistrantManager.removeRegistrantFromAllDivisions(dialogRegistrant);
            foreach (object o in divisionList.SelectedItems)
            {
                dialogRegistrant.Divisions.Add((Division)(Enum.Parse(typeof(Division), o.ToString())));
                DataManager.RegistrantManager.addRegistrant(dialogRegistrant);
            }
            Close();
        }

        private bool isValid()
        {
            return firstNameField.Text != "" && lastNameField.Text != "" && dojoField.Text != "";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
