using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public class RegistrantManager : IExportable, IImportable
    {
        Dictionary<Division, List<Registrant>> registrants = new Dictionary<Division, List<Registrant>>();
        public void clear()
        {
            registrants.Clear();
        }

        public List<Registrant> getSortedRegistrantList(Division division)
        {
            List<Registrant> regs = new List<Registrant>();
            registrants.TryGetValue(division, out regs);
            if (regs == null)
            {
                return new List<Registrant>();
            }
            return regs.OrderByDescending(g => (g.LastName + g.FirstName)).ToList();
        }

        public void addRegistrant(Registrant reg)
        {
            foreach (Division div in reg.Divisions)
            {
                addRegistrantToDivision(reg, div);
            }
        }

        private void addRegistrantToDivision(Registrant reg, Division div)
        {
            if (!registrants.ContainsKey(div))
            {
                registrants.Add(div, new List<Registrant>());
            }
            List<Registrant> regs = null;
            registrants.TryGetValue(div, out regs);
            if (!regs.Contains(reg))
            {
                regs.Add(reg);
            }
        }

        public void export(StreamWriter file)
        {
            file.WriteLine("#" + GetType().ToString());
            List<Registrant> parsedRegs = new List<Registrant>();
            foreach (Division div in Enum.GetValues(typeof(Division)))
            {
                if (!registrants.ContainsKey(div))
                    continue;
                foreach (Registrant exportable in registrants[div])
                {
                    if (!parsedRegs.Contains(exportable))
                    {
                        parsedRegs.Add(exportable);
                        exportable.export(file);
                    }
                }
            }
            file.WriteLine();
        }

        public string import(StreamReader file)
        {
            string line = ""; ;
            while ((line = file.ReadLine()) != null && line != "")
            {
                Registrant newReg = new Registrant();
                newReg.import(line);
                if (newReg.hasData())
                    addRegistrant(newReg);
            }
            return line;
        }

        public Registrant getRegistrantByID(String id, Division div)
        {
            if (registrants.ContainsKey(div))
            {
                foreach (Registrant r in registrants[div])
                {
                    if (r.ID.Equals(id))
                        return r;
                }
            }

            return null;
        }

        public void removeRegistrantFromAllDivisions(Registrant r)
        {
            foreach (Division div in registrants.Keys)
            {
                registrants[div].Remove(r);
            }
            r.Divisions.Clear();
        }

        public void printAllRegistrantsByDivision()
        {
            List<Registrant> seenRegistrants = new List<Registrant>();
            List<string> contents = new List<string>();
            foreach (Division div in registrants.Keys)
            {
                contents.AddRange(printAllRegistrantsForDivision(div, false, ref seenRegistrants));
            }
            new Printer(contents).Print();
        }

        public List<string> printAllRegistrantsForDivision(Division div, bool shouldPrint, ref List<Registrant> seenRegistrants)
        {
            List<string> contents = new List<string>();
            contents.Add("Registrants in " + div.ToString());
            contents.Add("________________________________________________________________________________");
            if (!registrants.ContainsKey(div) || registrants[div].Count == 0)
            {
                contents.Add("None");
                return contents;
            }
            foreach (Registrant r in registrants[div])
            {
                if (!seenRegistrants.Contains(r))
                {
                    contents.Add(r.FirstName + " " + r.LastName + " ( " + r.Dojo + " )");
                    seenRegistrants.Add(r);
                    contents.Add("");
                }

            }
            contents.Add("");
            if (shouldPrint)
            {
                new Printer(contents).Print();
            }
            return contents;
        }
    }
}
