namespace ShinsakaiWindowsApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addRegistrantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.registrantsTab = new System.Windows.Forms.TabPage();
            this.groupsTab = new System.Windows.Forms.TabPage();
            this.divCombo = new System.Windows.Forms.ComboBox();
            this.importButton = new System.Windows.Forms.Button();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisionRegistrantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbyOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupbyScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allRegistrantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRegistrantToolStripMenuItem,
            this.printToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1083, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addRegistrantToolStripMenuItem
            // 
            this.addRegistrantToolStripMenuItem.Name = "addRegistrantToolStripMenuItem";
            this.addRegistrantToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.addRegistrantToolStripMenuItem.Text = "Add Registrant";
            this.addRegistrantToolStripMenuItem.Click += new System.EventHandler(this.addRegistrantToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.importButton);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 48);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(926, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 33);
            this.button1.TabIndex = 0;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1083, 468);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Controls.Add(this.divCombo);
            this.splitContainer1.Size = new System.Drawing.Size(1081, 466);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.registrantsTab);
            this.tabControl1.Controls.Add(this.groupsTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 442);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // registrantsTab
            // 
            this.registrantsTab.Location = new System.Drawing.Point(4, 25);
            this.registrantsTab.Name = "registrantsTab";
            this.registrantsTab.Padding = new System.Windows.Forms.Padding(3);
            this.registrantsTab.Size = new System.Drawing.Size(450, 413);
            this.registrantsTab.TabIndex = 0;
            this.registrantsTab.Text = "Registrants";
            this.registrantsTab.UseVisualStyleBackColor = true;
            // 
            // groupsTab
            // 
            this.groupsTab.Location = new System.Drawing.Point(4, 25);
            this.groupsTab.Name = "groupsTab";
            this.groupsTab.Padding = new System.Windows.Forms.Padding(3);
            this.groupsTab.Size = new System.Drawing.Size(635, 413);
            this.groupsTab.TabIndex = 1;
            this.groupsTab.Text = "Groups";
            this.groupsTab.UseVisualStyleBackColor = true;
            // 
            // divCombo
            // 
            this.divCombo.Dock = System.Windows.Forms.DockStyle.Top;
            this.divCombo.FormattingEnabled = true;
            this.divCombo.Location = new System.Drawing.Point(0, 0);
            this.divCombo.Name = "divCombo";
            this.divCombo.Size = new System.Drawing.Size(458, 24);
            this.divCombo.TabIndex = 0;
            this.divCombo.SelectedIndexChanged += new System.EventHandler(this.divCombo_SelectedIndexChanged);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(775, 3);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(145, 33);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.divisionRegistrantsToolStripMenuItem,
            this.groupbyOrderToolStripMenuItem,
            this.groupbyScoreToolStripMenuItem,
            this.allRegistrantsToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // divisionRegistrantsToolStripMenuItem
            // 
            this.divisionRegistrantsToolStripMenuItem.Name = "divisionRegistrantsToolStripMenuItem";
            this.divisionRegistrantsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.divisionRegistrantsToolStripMenuItem.Text = "Division Registrants";
            this.divisionRegistrantsToolStripMenuItem.Click += new System.EventHandler(this.divisionRegistrantsToolStripMenuItem_Click);
            // 
            // groupbyOrderToolStripMenuItem
            // 
            this.groupbyOrderToolStripMenuItem.Name = "groupbyOrderToolStripMenuItem";
            this.groupbyOrderToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.groupbyOrderToolStripMenuItem.Text = "Group (by Order)";
            this.groupbyOrderToolStripMenuItem.Click += new System.EventHandler(this.groupbyOrderToolStripMenuItem_Click);
            // 
            // groupbyScoreToolStripMenuItem
            // 
            this.groupbyScoreToolStripMenuItem.Name = "groupbyScoreToolStripMenuItem";
            this.groupbyScoreToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.groupbyScoreToolStripMenuItem.Text = "Group (by score)";
            // 
            // allRegistrantsToolStripMenuItem
            // 
            this.allRegistrantsToolStripMenuItem.Name = "allRegistrantsToolStripMenuItem";
            this.allRegistrantsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.allRegistrantsToolStripMenuItem.Text = "All Registrants";
            this.allRegistrantsToolStripMenuItem.Click += new System.EventHandler(this.allRegistrantsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem addRegistrantToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage registrantsTab;
        private System.Windows.Forms.TabPage groupsTab;
        private System.Windows.Forms.ComboBox divCombo;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisionRegistrantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupbyOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupbyScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allRegistrantsToolStripMenuItem;
    }
}

