using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public static class Helper
    {
        public static void populateDropDownOptions(ComboBox cmBox)
        {
            foreach (Division r in Enum.GetValues(typeof(Division)))
            {
                cmBox.Items.Add(r.ToString());
            }
        }

        public static void populateListBoxOptions(ListBox cmBox)
        {
            foreach (Division r in Enum.GetValues(typeof(Division)))
            {
                cmBox.Items.Add(r.ToString());
            }
        }

        public static DialogResult showPrintDialog()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowSomePages = true;


            return printDialog.ShowDialog();
        }
    }
}
