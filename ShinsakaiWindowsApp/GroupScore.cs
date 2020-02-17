using System;
using System.Collections.Generic;

namespace ShinsakaiWindowsApp
{
    public class GroupScore
    {
        public CompetitionGroupType CompetitionGroupType { get; set; }
        private Dictionary<Registrant, Score> internalScoring = new Dictionary<Registrant, Score>();
        public List<KeyValuePair<Registrant, Score>> Scoring {
            get
            {
                List<KeyValuePair<Registrant, Score>> ret = new List<KeyValuePair<Registrant, Score>>();
                foreach (KeyValuePair<Registrant, Score> kvp in internalScoring)
                    ret.Add(kvp);
                return ret;
            }
        }

        Group group;

        public GroupScore(CompetitionGroupType competition, Group g)
        {
            CompetitionGroupType = competition;
            group = g;
            foreach(Registrant r in getRegistrants())
            {
                internalScoring.Add(r, new Score(CompetitionGroupType));
            }
        }

        public GroupScore(GroupScore gs)
        {
            CompetitionGroupType = gs.CompetitionGroupType;
            group = gs.group;
            foreach(KeyValuePair<Registrant, Score> kvp in gs.Scoring)
            {
                internalScoring.Add(kvp.Key, new Score(kvp.Value));
            }
        }

        public List<Registrant> getRegistrants()
        {
            List<Registrant> regs = new List<Registrant>();
            if (CompetitionGroupType == CompetitionGroupType.Rolling)
            {
                regs.Add(DataManager.DefaultRegistrant);
            }
            else
            {
                foreach(Registrant r in group.Registrants)
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

        public Score getScoreForRegistrant(Registrant r)
        {
            if(internalScoring.ContainsKey(r))
            {
                return internalScoring[r];
            }
            return null;
        }
    }
}
