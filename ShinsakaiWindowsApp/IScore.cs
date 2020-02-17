using System.Collections.Generic;

namespace ShinsakaiWindowsApp
{
    public interface IScore
    {
        void addScore(Judge judge, ScoringEntry entryKey, float value);
        List<ScoringEntry> getRows();
        float getTotal();
    }

    public class Score : IScore
    {
        private Dictionary<Judge, Dictionary<ScoringEntry, float>> internalScores = new Dictionary<Judge, Dictionary<ScoringEntry, float>>();
        public List<KeyValuePair<Judge, Dictionary<ScoringEntry, float>>> Scores {
            get
            {
                List<KeyValuePair<Judge, Dictionary<ScoringEntry, float>>> ret = new List<KeyValuePair<Judge, Dictionary<ScoringEntry, float>>>();
                foreach (KeyValuePair<Judge, Dictionary<ScoringEntry, float>> kvp in internalScores)
                    ret.Add(kvp);
                return ret;
            }
        }
        private CompetitionGroupType competitionType;

        public Score(CompetitionGroupType competitionType)
        {
            this.competitionType = competitionType;
        }

        public Score(Score sc)
        {
            competitionType = sc.competitionType;
            
            foreach(KeyValuePair<Judge, Dictionary<ScoringEntry, float>> judge in sc.Scores)
            {
                Dictionary<ScoringEntry, float> newJudgeScore = new Dictionary<ScoringEntry, float>();
                foreach(KeyValuePair<ScoringEntry, float> kvp in judge.Value)
                {
                    newJudgeScore.Add(kvp.Key, kvp.Value);
                }
                // Clear old data
                if (internalScores.ContainsKey(judge.Key))
                    internalScores.Remove(judge.Key);
                //Set new data
                internalScores.Add(judge.Key, newJudgeScore);
            }
        }

        public List<ScoringEntry> getRows()
        {
            return competitionType.getScoringEntries();
        }

        protected void addJudge(Judge j)
        {
            // Clear old data
            if (internalScores.ContainsKey(j))
                internalScores.Remove(j);

            Dictionary<ScoringEntry, float> score = new Dictionary<ScoringEntry, float>();
            foreach (ScoringEntry entry in competitionType.getScoringEntries())
            {
                score.Add(entry, 0.0f);
            }
            internalScores.Add(j, score);
        }

        public void addScore(Judge judge, ScoringEntry entryKey, float value)
        {
            if (!internalScores.ContainsKey(judge))
            {
                internalScores.Add(judge, new Dictionary<ScoringEntry, float>());
            }
            (internalScores[judge])[entryKey] = value;
        }

        public float getTotal()
        {
            if(Scores.Count == 0)
            {
                return 0.0f;
            }
            float sum = 0.0f;
            foreach(KeyValuePair<Judge, Dictionary<ScoringEntry, float>> judging in Scores)
            {
                foreach (KeyValuePair<ScoringEntry, float> kvp in judging.Value)
                {
                    sum += kvp.Value;
                }
            }
            return sum;
        }
    }

}
