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
            foreach (Belt r in Enum.GetValues(typeof(Belt)))
            {
                beltCombo.Items.Add(r.ToString());
            }

            foreach (ShirtSize r in Enum.GetValues(typeof(ShirtSize)))
            {
                shirtCombo.Items.Add(r.getDesc());
            }

            dialogRegistrant = reg;
            firstNameField.Text = reg.FirstName;
            lastNameField.Text = reg.LastName;
            dojoField.Text = reg.Dojo;
            senseiField.Text = reg.Sensei;
            beltCombo.SelectedItem = reg.Belt.ToString();
            shirtCombo.SelectedItem = reg.ShirtSize.getDesc();

            foreach (Division div in reg.Divisions)
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
            dialogRegistrant.Belt = (Belt)Enum.Parse(typeof(Belt), beltCombo.SelectedText);
            dialogRegistrant.ShirtSize = (ShirtSize)Enum.Parse(typeof(ShirtSize), shirtCombo.SelectedText);
            dialogRegistrant.Sensei = senseiField.Text;
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
            Close();
        }
    }
}
