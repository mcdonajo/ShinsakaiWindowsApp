using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public class GroupsPanel : Panel
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GroupsPanel
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResumeLayout(false);

        }

        public GroupsPanel()
        {
            InitializeComponent();
        }

        public void refreshGroups(Division division)
        {
            SuspendLayout();
            Controls.Clear();
            List<Group> groups = DataManager.GroupManager.getSortedGroupList(DataManager.CurrentDivision);
            groups.Reverse();
            foreach (Group g in groups)
            {
                GroupPanel groupPanel = new GroupPanel(g);
                Controls.Add(groupPanel);
                groupPanel.Dock = DockStyle.Top;
            }
            ResumeLayout(true);
        }
    }
}
