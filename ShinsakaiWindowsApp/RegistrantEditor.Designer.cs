namespace ShinsakaiWindowsApp
{
    partial class RegistrantEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firstNameField = new System.Windows.Forms.TextBox();
            this.lastNameField = new System.Windows.Forms.TextBox();
            this.dojoField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.divisionList = new System.Windows.Forms.ListBox();
            this.senseiField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.beltCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.shirtCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Home Dojo";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(12, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Division";
            // 
            // firstNameField
            // 
            this.firstNameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstNameField.Location = new System.Drawing.Point(97, 6);
            this.firstNameField.Name = "firstNameField";
            this.firstNameField.Size = new System.Drawing.Size(317, 22);
            this.firstNameField.TabIndex = 4;
            // 
            // lastNameField
            // 
            this.lastNameField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastNameField.Location = new System.Drawing.Point(97, 29);
            this.lastNameField.Name = "lastNameField";
            this.lastNameField.Size = new System.Drawing.Size(317, 22);
            this.lastNameField.TabIndex = 5;
            // 
            // dojoField
            // 
            this.dojoField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dojoField.Location = new System.Drawing.Point(97, 52);
            this.dojoField.Name = "dojoField";
            this.dojoField.Size = new System.Drawing.Size(317, 22);
            this.dojoField.TabIndex = 6;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(339, 306);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(258, 306);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // divisionList
            // 
            this.divisionList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.divisionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.divisionList.FormattingEnabled = true;
            this.divisionList.ItemHeight = 16;
            this.divisionList.Location = new System.Drawing.Point(97, 186);
            this.divisionList.Name = "divisionList";
            this.divisionList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.divisionList.Size = new System.Drawing.Size(317, 114);
            this.divisionList.TabIndex = 10;
            // 
            // senseiField
            // 
            this.senseiField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senseiField.Location = new System.Drawing.Point(97, 75);
            this.senseiField.Name = "senseiField";
            this.senseiField.Size = new System.Drawing.Size(317, 22);
            this.senseiField.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sensei";
            // 
            // beltCombo
            // 
            this.beltCombo.FormattingEnabled = true;
            this.beltCombo.Location = new System.Drawing.Point(97, 98);
            this.beltCombo.Name = "beltCombo";
            this.beltCombo.Size = new System.Drawing.Size(317, 24);
            this.beltCombo.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Belt";
            // 
            // shirtCombo
            // 
            this.shirtCombo.FormattingEnabled = true;
            this.shirtCombo.Location = new System.Drawing.Point(97, 123);
            this.shirtCombo.Name = "shirtCombo";
            this.shirtCombo.Size = new System.Drawing.Size(317, 24);
            this.shirtCombo.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Shirt Size";
            // 
            // RegistrantEditor
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(430, 342);
            this.Controls.Add(this.shirtCombo);
            this.Controls.Add(this.beltCombo);
            this.Controls.Add(this.senseiField);
            this.Controls.Add(this.divisionList);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dojoField);
            this.Controls.Add(this.lastNameField);
            this.Controls.Add(this.firstNameField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Name = "RegistrantEditor";
            this.Text = "Registrant Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox firstNameField;
        private System.Windows.Forms.TextBox lastNameField;
        private System.Windows.Forms.TextBox dojoField;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox divisionList;
        private System.Windows.Forms.TextBox senseiField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox beltCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox shirtCombo;
        private System.Windows.Forms.Label label7;
    }
}