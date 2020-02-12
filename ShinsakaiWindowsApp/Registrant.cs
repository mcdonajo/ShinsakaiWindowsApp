using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinsakaiWindowsApp
{
    public class RegistrantData
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Dojo { get; set; } = "";
        public List<Division> Divisions { get; set; } = new List<Division>();
        public string ID { get; set; } = DataManager.GetGuid();

        public bool hasData()
        {
            return !(FirstName.Length == 0 || LastName.Length == 0 || Dojo.Length == 0 || Divisions.Count == 0);
        }
    }

    public class Registrant : IExportable
    {
        List<Group> groups = new List<Group>();

        public RegistrantData RegistrantData { get; } = new RegistrantData();

        public static Registrant DefaultRegistrant { get; } = new Registrant();

        public string ID
        {
            get { return RegistrantData.ID; }
            set { RegistrantData.ID = value; }
        }

        public string FirstName
        {
            get { return RegistrantData.FirstName; }
            set { RegistrantData.FirstName = value; }
        }

        public string LastName
        {
            get { return RegistrantData.LastName; }
            set { RegistrantData.LastName = value; }
        }

        public string Dojo
        {
            get { return RegistrantData.Dojo; }
            set { RegistrantData.Dojo = value; }
        }

        public List<Division> Divisions
        {
            get { return RegistrantData.Divisions; }
            set
            {
                RegistrantData.Divisions.Clear();
                RegistrantData.Divisions.AddRange(value);
            }
        }

        public void export(StreamWriter file)
        {
            string output = ID + "," + FirstName + "," + LastName + "," + Dojo;
            foreach (Division div in Divisions)
            {
                output += "," + div.ToString();
            }
            file.WriteLine(output);
        }

        public void addGroup(Group group)
        {
            groups.Add(group);
        }

        public void removeGroup(Group group)
        {
            groups.Remove(group);
        }

        public Boolean hasData()
        {
            return RegistrantData.hasData();
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
