using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    class RegistrantPanel : Panel
    {
        private Label dojoLabel;
        private Label nameLabel;

        public Registrant Registrant { get; set; }

        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.dojoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AllowDrop = true;
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 17);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragDrop);
            this.nameLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragEnter);
            this.nameLabel.DragLeave += new System.EventHandler(this.RegistrantPanel_DragLeave);
            this.nameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegistrantPanel_MouseDown);
            this.nameLabel.MouseEnter += new System.EventHandler(this.RegistrantPanel_MouseEnter);
            this.nameLabel.MouseLeave += new System.EventHandler(this.RegistrantPanel_MouseLeave);
            // 
            // dojoLabel
            // 
            this.dojoLabel.AllowDrop = true;
            this.dojoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dojoLabel.AutoSize = true;
            this.dojoLabel.Location = new System.Drawing.Point(0, 18);
            this.dojoLabel.Name = "dojoLabel";
            this.dojoLabel.Size = new System.Drawing.Size(0, 17);
            this.dojoLabel.TabIndex = 1;
            this.dojoLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragDrop);
            this.dojoLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragEnter);
            this.dojoLabel.DragLeave += new System.EventHandler(this.RegistrantPanel_DragLeave);
            this.dojoLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegistrantPanel_MouseDown);
            this.dojoLabel.MouseEnter += new System.EventHandler(this.RegistrantPanel_MouseEnter);
            this.dojoLabel.MouseLeave += new System.EventHandler(this.RegistrantPanel_MouseLeave);
            // 
            // RegistrantPanel
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.dojoLabel);
            this.Size = new System.Drawing.Size(300, 35);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RegistrantPanel_DragEnter);
            this.DragLeave += new System.EventHandler(this.RegistrantPanel_DragLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegistrantPanel_MouseDown);
            this.MouseEnter += new System.EventHandler(this.RegistrantPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.RegistrantPanel_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public RegistrantPanel(Registrant reg)
        {
            Registrant = reg;
            InitializeComponent();
            nameLabel.Text = "NAME: " + reg.LastName + ", " + reg.FirstName;
            dojoLabel.Text = "DOJO: " + reg.Dojo;
            this.PerformLayout();
            this.Refresh();
        }

        private void RegistrantPanel_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void RegistrantPanel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        }

        private void RegistrantPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.All);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Registrant r = Registrant;
                RegistrantEditor editor = new RegistrantEditor(ref r);
                editor.ShowDialog();
                if (editor.DialogResult == DialogResult.OK && Registrant.hasData())
                {
                    ((RegistrantsPanel)Parent).refreshRegistrants(DataManager.CurrentDivision);
                }
            }
        }

        private void RegistrantPanel_DragEnter(object sender, DragEventArgs e)
        {
            RegistrantPanel_MouseEnter(this, e);
            e.Effect = DragDropEffects.Move;
        }

        private void RegistrantPanel_DragLeave(object sender, EventArgs e)
        {
            RegistrantPanel_MouseLeave(this, e);
        }

        private void RegistrantPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(RegistrantPanel)))
            {
                RegistrantPanel item = (RegistrantPanel)e.Data.GetData(typeof(RegistrantPanel));
                Group g = new Group();
                if (Registrant != item.Registrant)
                {
                    g.addRegistrant(Registrant);
                    g.addRegistrant(item.Registrant);
                    g.Division = DataManager.CurrentDivision;
                    DataManager.GroupManager.addGroup(g, g.Division);
                }
                
            }
        }
    }
}
