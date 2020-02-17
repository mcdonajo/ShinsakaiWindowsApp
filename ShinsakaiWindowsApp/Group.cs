using System;
using System.Collections.Generic;
using System.IO;


namespace ShinsakaiWindowsApp
{
    public class Group : IExportable
    {
        public GroupScore GroupScore { get; set; } = null;
        public int Order { get; set; }
        public Division Division { get; set; }
        public string ID { get; set; } = DataManager.GetGuid();
        public List<Registrant> Registrants { get; set;  } = new List<Registrant>();

        public void addRegistrant(Registrant reg)
        {
            if(!Registrants.Contains(reg))
            {
                Registrants.Add(reg);
            }
            
        }

        public void removeRegistrant(Registrant reg)
        {
            if (reg != null && Registrants.Contains(reg))
            {
                Registrants.Remove(reg);
            }

            if (Registrants.Count <2)
            {
                Registrants.Clear();
                DataManager.GroupManager.removeGroup(this, Division);
            }
        }

        public Registrant findRegistrantByGroupTag(string groupTag)
        {
            foreach(Registrant r in Registrants)
            {
                if (generateGroupPanelString(r).Equals(groupTag))
                {
                    return r;
                }
            }
            return null;
        }

        public string generateGroupPanelString(Registrant reg)
        {
            return reg.LastName + ", " + reg.FirstName + " (" + reg.Dojo + ")";
        }

        public void export(StreamWriter file)
        {
            string output = ID + "," + Order.ToString() + "," + Division.ToString();
            foreach(Registrant reg in Registrants)
            {
                output += "," + reg.ID;
            }
            file.WriteLine(output);
        }

        public void import(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 5)
                return;
            ID = parts[0];
            Order = Int16.Parse(parts[1]);
            Division = (Division)(Enum.Parse(typeof(Division), parts[2]));
            for (int i = 3; i < parts.Length; i++)
            {
                Registrant r = DataManager.RegistrantManager.getRegistrantByID(parts[i], Division);
                if (r != null)
                    addRegistrant(r);
            }
        }

        public void clear()
        {

        }
    }
}