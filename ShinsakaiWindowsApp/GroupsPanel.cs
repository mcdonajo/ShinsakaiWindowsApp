using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public class GroupsPanel : Panel
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupsPanel));
            this.SuspendLayout();
            // 
            // GroupsPanel
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
