using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public class Registrant : IExportable
    {
        public string ID { get; set; } = DataManager.GetGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Dojo { get; set; } = "";
        public List<Division> Divisions { get; set; } = new List<Division>();

        //public string FullName { get { return LastName + ", " + FirstName; } }

        public void export(StreamWriter file)
        {
            string output = ID + "," + FirstName + "," + LastName + "," + Dojo;
            foreach (Division div in Divisions)
            {
                output += "," + div.ToString();
            }
            file.WriteLine(output);
        }

        public bool hasData()
        {
            return !(FirstName.Length == 0 || LastName.Length == 0 || Dojo.Length == 0 || Divisions.Count == 0);
        }

        public void import(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 5)
                return;
            ID = parts[0];
            FirstName = parts[1];
            LastName = parts[2];
            Dojo = parts[3];
            if(!ID.Equals(parts[0]))
            {
                MessageBox.Show("Error importing " + FirstName + " " + LastName);
            }
            for(int i = 4; i < parts.Length; i++)
            {
                Divisions.Add((Division)(Enum.Parse(typeof(Division), parts[i])));
            }
        }
    }
}