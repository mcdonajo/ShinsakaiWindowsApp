using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public static class DataManager
    {
        public static Division CurrentDivision { get; set; } = Division.Division1;
        public static CompetitionGroupType CurrentCompetition { get; set; } = CompetitionGroupType.Rolling;
        public static GroupManager GroupManager { get; set; } = new GroupManager();
        public static RegistrantManager RegistrantManager { get; set; } = new RegistrantManager();

        public static Registrant DefaultRegistrant { get; } = new Registrant();

        public static void export(String fileName)
        {
            using (StreamWriter sr = new StreamWriter(fileName))
            {
                RegistrantManager.export(sr);
                GroupManager.export(sr);
            }
        }

        public static void import(string fileName)
        {
            RegistrantManager.clear();
            GroupManager.clear();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.StartsWith("#"))
                    {
                        line = line.TrimStart('#');
                        if (line.Equals(RegistrantManager.GetType().ToString()))
                        {
                            line = RegistrantManager.import(sr);
                            
                        }
                            
                        if (line.Equals(GroupManager.GetType().ToString()))
                            GroupManager.import(sr);
                    }
                }
                
            }
        }

        private static void parseLine(string line, StreamReader sr)
        {
            string line2 = line;
            while(line2 != "" && !sr.EndOfStream)
            {
                if (line2.StartsWith("#"))
                {
                    line2 = line2.TrimStart('#');
                    if (line2.Equals(RegistrantManager.GetType().ToString()))
                    {
                        line2 = RegistrantManager.import(sr);
                        continue;
                    }

                    if (line2.Equals(GroupManager.GetType().ToString()))
                    {
                        line2 = GroupManager.import(sr);
                        continue;
                    }
                }
                else
                {
                    line2 = "";
                }
            }
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
