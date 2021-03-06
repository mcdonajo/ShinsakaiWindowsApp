﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public partial class MainForm : Form
    {
        int idx = 0;
        RegistrantsPanel groupRegistrants;
        WebServer webServer;

        public MainForm()
        {
            InitializeComponent();
            setUpRegistrantsPanelForGroup();
            setUpGroupsPanel();
            Helper.populateDropDownOptions(divCombo);
            divCombo.SelectedItem = DataManager.CurrentDivision.ToString();
            tabControl1_SelectedIndexChanged(null, null);
            webServer = new WebServer();
            Thread webServerThread = new Thread(new ThreadStart(webServer.Listen));
            webServerThread.Start();
        }

        private void addRegistrantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registrant reg = new Registrant();
            RegistrantEditor regEditor = new RegistrantEditor(ref reg);
            regEditor.ShowDialog();
            if (regEditor.DialogResult == DialogResult.OK && reg.hasData())
            {
                DataManager.RegistrantManager.addRegistrant(reg);
                groupRegistrants.refreshRegistrants(DataManager.CurrentDivision);
            }
        }

        private void addTestReg()
        {
            Registrant reg = new Registrant();
            reg.Divisions = new List<Division>() { DataManager.CurrentDivision };
            reg.FirstName = "Joe" + idx;
            reg.LastName = "McDonald" + idx;
            reg.Dojo = "West linn" + idx;
            idx++;
            DataManager.RegistrantManager.addRegistrant(reg);
            groupRegistrants.refreshRegistrants(DataManager.CurrentDivision);
        }

        private void setUpRegistrantsPanelForGroup()
        {
            groupRegistrants = new RegistrantsPanel();
            groupsTab.Controls.Add(groupRegistrants);
            groupRegistrants.Dock = DockStyle.Fill;
            groupRegistrants.Size = groupsTab.Size;
            groupRegistrants.AllowDrop = true;
            groupRegistrants.PerformLayout();
        }

        private void setUpGroupsPanel()
        {
            splitContainer1.Panel2.Controls.Add(DataManager.GroupManager.GroupsPanel);
            DataManager.GroupManager.GroupsPanel.Dock = DockStyle.Fill;
            DataManager.GroupManager.GroupsPanel.Size = groupsTab.Size;
            DataManager.GroupManager.GroupsPanel.PerformLayout();
            DataManager.GroupManager.GroupsPanel.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == groupsTab)
            {
                DataManager.GroupManager.GroupsPanel.Visible = true;
            } else
            {
                DataManager.GroupManager.GroupsPanel.Visible = false;
            }
        }

        private void divCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataManager.CurrentDivision = (Division)(Enum.Parse(typeof(Division), divCombo.SelectedItem.ToString()));
            groupRegistrants.refreshRegistrants(DataManager.CurrentDivision);
            DataManager.GroupManager.updateUI(DataManager.CurrentDivision);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataManager.export(getRegistrantInfoFile());
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            DataManager.import(getRegistrantInfoFile());
            groupRegistrants.refreshRegistrants(DataManager.CurrentDivision);
            DataManager.GroupManager.updateUI(DataManager.CurrentDivision);
        }

        private string getRegistrantInfoFile()
        {
            string currPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string filePath = currPath + System.IO.Path.DirectorySeparatorChar + "RegistrantInfo.csv";
            return filePath;
        }

        private void groupbyOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.showPrintDialog() == DialogResult.OK)
            {
                DataManager.GroupManager.printOrderGroupsForDivision(DataManager.CurrentDivision);
            }
            
        }

        private void allRegistrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.showPrintDialog() == DialogResult.OK)
            {
                DataManager.RegistrantManager.printAllRegistrantsByDivision();
            }
        }

        private void divisionRegistrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Helper.showPrintDialog() == DialogResult.OK)
            {
                List<Registrant> seenRegistrants = new List<Registrant>();
                DataManager.RegistrantManager.printAllRegistrantsForDivision(DataManager.CurrentDivision, true, ref seenRegistrants);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            webServer.end();
        }

        private void sortByOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uncheckSortOptions();
            sortByOrderToolStripMenuItem.Checked = true;
            DataManager.GroupManager.GroupSorter = new OrderGroupSorter();
            DataManager.GroupManager.GroupsPanel.refreshGroups(DataManager.CurrentDivision);
        }

        private void sortByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uncheckSortOptions();
            sortByScoreToolStripMenuItem.Checked = true;
            DataManager.GroupManager.GroupSorter = new ScoreGroupSorter();
            DataManager.GroupManager.GroupsPanel.refreshGroups(DataManager.CurrentDivision);
        }

        private void uncheckSortOptions()
        {
            sortByScoreToolStripMenuItem.Checked = false;
            sortByOrderToolStripMenuItem.Checked = false;
        }
    }
}
