using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    class GroupPanel : Panel
    {
        private Dictionary<Control, bool> draggedout = new Dictionary<Control, bool>();
        public Group Group { get; set; }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GroupPanel
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GroupPanel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.GroupPanel_DragEnter);
            this.DragLeave += new System.EventHandler(this.GroupPanel_DragLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GroupPanel_MouseDown);
            this.MouseEnter += new System.EventHandler(this.GroupPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.GroupPanel_MouseLeave);
            this.ResumeLayout(false);

        }

        public GroupPanel(Group group)
        {
            Group = group;
            InitializeComponent();
            addRegistrants();
        }

        private void addRegistrants()
        {
            foreach (Registrant reg in Group.getRegistrants())
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Size = new System.Drawing.Size(100, 15);
                label.Dock = DockStyle.Top;
                label.Text = reg.LastName + ", " + reg.FirstName + " (" + reg.Dojo + ")";
                label.AllowDrop = true;
                label.MouseDown += new MouseEventHandler(this.Label_MouseDown);
                label.MouseEnter += new EventHandler(this.Label_MouseEnter);
                label.MouseLeave += new EventHandler(this.Label_MouseLeave);
                label.DragDrop += new DragEventHandler(this.GroupPanel_DragDrop);
                label.DragEnter += new DragEventHandler(this.GroupPanel_DragEnter);
                label.DragLeave += new EventHandler(this.GroupPanel_DragLeave);
                draggedout.Add(label, false);
                this.Controls.Add(label);
            }
            this.Height = Group.getRegistrants().Count * 15;
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            GroupPanel_MouseEnter(this, e);
            ((Label)sender).ForeColor = System.Drawing.Color.Red;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            GroupPanel_MouseLeave(this, e);
            ((Label)sender).ForeColor = this.ForeColor;
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Registrant r = Group.findRegistrantByGroupTag(((Label)sender).Text);
                if (r != null)
                {
                    Group.removeRegistrant(r);
                    DataManager.GroupManager.updateUI(Group.Division);
                }
            }
            else
            {
                GroupPanel_MouseDown(this, e);
            }
        }

        private void GroupPanel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void GroupPanel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void GroupPanel_DragEnter(object sender, DragEventArgs e)
        {
            GroupPanel_MouseEnter(this, e);
            e.Effect = DragDropEffects.Move;
        }

        private void GroupPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(RegistrantPanel)))
            {
                RegistrantPanel item = (RegistrantPanel)e.Data.GetData(typeof(RegistrantPanel));
                Group.addRegistrant(item.Registrant);
                DataManager.GroupManager.updateUI(Group.Division);
            }
            if (e.Data.GetDataPresent(typeof(GroupPanel)))
            {
                GroupPanel item = (GroupPanel)e.Data.GetData(typeof(GroupPanel));
                item.Group.Order = Group.Order;
                DataManager.GroupManager.reorder(item.Group);
                DataManager.GroupManager.updateUI(Group.Division);
            }
        }

        private void GroupPanel_DragLeave(object sender, EventArgs e)
        {
            GroupPanel_MouseLeave(this, e);
        }

        private void GroupPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.All);
            }

            else if (e.Button == MouseButtons.Right)
            {
                ScoringForm sForm = new ScoringForm(Group);
                if (sForm.ShowDialog() == DialogResult.OK)
                {
                    Group.GroupScore = sForm.GroupScore;
                }
            }
        }
    }
}
