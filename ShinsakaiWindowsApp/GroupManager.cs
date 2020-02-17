using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShinsakaiWindowsApp
{
    public class GroupManager : IExportable, IImportable
    {
        private static int numGroups = 0;
        private Dictionary<Division, List<Group>> divGroups = new Dictionary<Division, List<Group>>();
        public GroupsPanel GroupsPanel { get; set; } = new GroupsPanel();

        public List<Group> getSortedGroupList(Division division)
        {
            List<Group> groups = new List<Group>();
            divGroups.TryGetValue(division, out groups);
            if (groups == null)
            {
                return new List<Group>();
            }
            return groups.OrderBy(g => g.Order).ToList();
        }

        public Group getGroup(string groupID)
        {
            foreach(KeyValuePair<Division, List<Group>> groupsPerDivision in divGroups)
            {
                foreach(Group g in groupsPerDivision.Value)
                {
                    if (groupID.Equals(g.ID))
                        return g;
                }
            }
            return null;
        }

        public void addGroup(Group g, Division div)
        {
            if (!divGroups.ContainsKey(div))
            {
                divGroups.Add(div, new List<Group>());
            }
            List<Group> groups = getGroupForDivision(div);
            groups.Add(g);
            g.Order = numGroups;
            numGroups++;
            updateUI(div);
        }

        public void removeGroup(Group g, Division div)
        {
            List<Group> groups = getGroupForDivision(div);
            if (groups != null && groups.Contains(g))
            {
                groups.Remove(g);
                updateUI(div);
            }
        }

        private List<Group> getGroupForDivision(Division div)
        {
            List<Group> groups = null;
            divGroups.TryGetValue(div, out groups);
            return groups;
        }

        public void updateUI(Division div)
        {
            GroupsPanel.refreshGroups(div);
        }

        public void reorder(Group group)
        {
            List<Group> sortedList = getSortedGroupList(group.Division);
            int orderNo = 0;
            foreach (Group g in sortedList)
            {
                if (g == group)
                {
                    continue;
                }
                if (g.Order == group.Order)
                {
                    group.Order = orderNo;
                    orderNo++;
                    g.Order = orderNo;
                }
                else
                {
                    g.Order = orderNo;
                }
                orderNo++;
            }
        }

        public void export(StreamWriter file)
        {
            file.WriteLine("#" + GetType().ToString());
            List<Group> parsedGroups = new List<Group>();
            foreach (Division div in Enum.GetValues(typeof(Division)))
            {
                if (!divGroups.ContainsKey(div))
                    continue;
                foreach (Group exportable in divGroups[div])
                {
                    if (!parsedGroups.Contains(exportable))
                    {
                        parsedGroups.Add(exportable);
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
                Group newGroup = new Group();
                newGroup.import(line);
                if (newGroup.Registrants.Count >= 2)
                    addGroup(newGroup, newGroup.Division);
            }
            return line;
        }

        public void clear()
        {
            foreach (Division div in Enum.GetValues(typeof(Division)))
            {
                if (!divGroups.ContainsKey(div))
                    continue;
                foreach (Group g in divGroups[div])
                {
                    g.clear();
                }
                divGroups[div].Clear();
            }
            divGroups.Clear();
        }

        public List<string> getPrintContentsForDivision(Division div)
        {
            List<string> contents = new List<string>();
            contents.Add("Groups in " + div.ToString());
            if (!divGroups.ContainsKey(div))
            {
                return contents;
            }
            foreach (Group g in getSortedGroupList(div))
            {
                if (g.GroupScore != null && g.GroupScore.getRegistrants() != null)
                {
                    float sum = 0.0f;
                    foreach (Registrant r in g.GroupScore.getRegistrants())
                        sum += g.GroupScore.getScoreForRegistrant(r).getTotal();
                    contents.Add(sum.ToString("F2").PadLeft(80, '_'));
                }
                else
                {
                    contents.Add("________________________________________________________________________________");
                }
                
                
                foreach (Registrant r in g.Registrants)
                {
                    contents.Add(r.FirstName + " " + r.LastName + "  ( " + r.Dojo + " Dojo)");
                }
                contents.Add("");
                contents.Add("");
            }
            return contents;
        }

        public void printOrderGroupsForDivision(Division div)
        {
            List<string> contents = getPrintContentsForDivision(div);
            if (contents.Count != 0)
                new Printer(contents).Print();
        }
    }
}
