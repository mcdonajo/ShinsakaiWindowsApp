using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    class RegistrantsPanel : Panel
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RegistrantsPanel
            // 
            this.AutoScroll = true;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout(false);

        }

        public RegistrantsPanel()
        {
            InitializeComponent();
        }

        public void refreshRegistrants(Division division)
        {
            SuspendLayout();
            Controls.Clear();
            List<Registrant> regs = DataManager.RegistrantManager.getSortedRegistrantList(DataManager.CurrentDivision);
            foreach(Registrant reg in regs) {
                RegistrantPanel regPanel = new RegistrantPanel(reg);
                Controls.Add(regPanel);
                regPanel.Dock = DockStyle.Top;
            }
            ResumeLayout(true);
        }
    }
}
