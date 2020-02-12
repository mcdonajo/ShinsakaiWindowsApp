using System;
using System.Collections.Generic;

namespace ShinsakaiWindowsApp
{
    public class GroupScore
    {
        public CompetitionGroupType CompetitionGroupType { get; set; }
        Group group;
        Dictionary<Registrant, Score> scoring = new Dictionary<Registrant, Score>();

        public GroupScore(CompetitionGroupType competition, Group g)
        {
            CompetitionGroupType = competition;
            group = g;
            foreach(Registrant r in getRegistrants())
            {
                scoring.Add(r, new Score(CompetitionGroupType));
            }
        }

        public GroupScore(GroupScore gs)
        {
            CompetitionGroupType = gs.CompetitionGroupType;
            group = gs.group;
            foreach(KeyValuePair<Registrant, Score> kvp in gs.scoring)
            {
                scoring.Add(kvp.Key, new Score(kvp.Value));
            }
        }

        public List<Registrant> getRegistrants()
        {
            List<Registrant> regs = new List<Registrant>();
            if (CompetitionGroupType == CompetitionGroupType.Rolling)
            {
                regs.Add(Registrant.DefaultRegistrant);
            }
            else
            {
                foreach(Registrant r in group.getRegistrants())
                {
                    regs.Add(r);
                }
            }
            return regs;
        }

        public List<ScoringEntry> getRows()
        {
            return CompetitionGroupType.getScoringEntries();
        }

        public IScore getScoreForRegistrant(Registrant r)
        {
            if(scoring.ContainsKey(r))
            {
                return scoring[r];
            }
            return null;
        }
    }
}
