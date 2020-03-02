using System;
using System.Collections.Generic;
using System.IO;

namespace ShinsakaiWindowsApp
{
    public class Registrant : IExportable
    {
        public string ID { get; set; } = DataManager.GetGuid();
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Dojo { get; set; } = "";
        public string Sensei { get; set; } = "";
        public ShirtSize ShirtSize { get; set; } = ShirtSize.None;
        public Belt Belt { get; set; } = Belt.White;
        public List<Division> Divisions { get; set; } = new List<Division>();

        public void export(StreamWriter file)
        {
            string output = ID + "," + FirstName + "," + LastName + "," + Dojo + "," + Sensei + "," + Belt + "," + ShirtSize;
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

        public bool import(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 8)
            {
                return false;
            }
            try
            {
                ID = parts[0];
                FirstName = parts[1];
                LastName = parts[2];
                Dojo = parts[3];
                Sensei = parts[4];
                Belt = (Belt)Enum.Parse(typeof(Belt), parts[5]);
                ShirtSize = (ShirtSize)Enum.Parse(typeof(ShirtSize), parts[6]);
                for (int i = 7; i < parts.Length; i++)
                {
                    Divisions.Add((Division)(Enum.Parse(typeof(Division), parts[i])));
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}