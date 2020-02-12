using System;
using System.Collections.Generic;
using System.IO;

namespace ShinsakaiWindowsApp
{
    public class Group : IExportable
    {
        private List<Registrant> registrants = new List<Registrant>();

        public GroupScore GroupScore { get; set; } = null;
        public int Order { get; set; }
        public Division Division { get; set; }
        public string ID { get; set; } = DataManager.GetGuid();

        public void addRegistrant(Registrant reg)
        {
            if(!registrants.Contains(reg))
            {
                registrants.Add(reg);
                reg.addGroup(this);
            }
            
        }

        public void removeRegistrant(Registrant reg)
        {
            if (reg != null && registrants.Contains(reg))
            {
                registrants.Remove(reg);
                reg.removeGroup(this);
            }

            if (registrants.Count <2)
            {
                foreach(Registrant r in registrants)
                {
                    r.removeGroup(this);
                }
                registrants.Clear();
                DataManager.GroupManager.removeGroup(this, Division);
            }
        }

        public List<Registrant> getRegistrants()
        {
            return registrants;
        }

        public Registrant findRegistrantByGroupTag(string groupTag)
        {
            foreach(Registrant r in getRegistrants())
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

        public override bool Equals(object value)
        {
            Group g = value as Group;
            if (g != null)
            {
                if (g.getRegistrants().Count != registrants.Count)
                {
                    return false;
                }
                foreach( Registrant r in g.getRegistrants())
                {
                    if (!registrants.Contains(r)) { return false; }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void export(StreamWriter file)
        {
            string output = ID + "," + Order.ToString() + "," + Division.ToString();
            foreach(Registrant reg in registrants)
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
            foreach(Registrant r in registrants)
            {
                r.removeGroup(this);
            }
        }
    }
}
