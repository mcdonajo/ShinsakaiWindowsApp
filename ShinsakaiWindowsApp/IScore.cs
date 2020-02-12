using System.Collections.Generic;

namespace ShinsakaiWindowsApp
{
    public interface IScore
    {
        void addScore(Judge judge, ScoringEntry entryKey, float value);
        Dictionary<Judge, Dictionary<ScoringEntry, float>> getScores();
        List<ScoringEntry> getRows();
        float getTotal();
    }

    class Score : IScore
    {
        Dictionary<Judge, Dictionary<ScoringEntry, float>> scores = new Dictionary<Judge, Dictionary<ScoringEntry, float>>();
        private CompetitionGroupType competitionType;

        public Score(CompetitionGroupType competitionType)
        {
            this.competitionType = competitionType;
        }

        public Score(Score sc)
        {
            competitionType = sc.competitionType;
            
            foreach(KeyValuePair<Judge, Dictionary<ScoringEntry, float>> judge in sc.scores)
            {
                Dictionary<ScoringEntry, float> newJudgeScore = new Dictionary<ScoringEntry, float>();
                foreach(KeyValuePair<ScoringEntry, float> kvp in judge.Value)
                {
                    newJudgeScore.Add(kvp.Key, kvp.Value);
                }
                // Clear old data
                if (scores.ContainsKey(judge.Key))
                    scores.Remove(judge.Key);
                //Set new data
                scores.Add(judge.Key, newJudgeScore);
            }
        }

        public Dictionary<Judge, Dictionary<ScoringEntry, float>> getScores()
        {
            return scores;
        }

        public List<ScoringEntry> getRows()
        {
            return competitionType.getScoringEntries();
        }

        protected void addJudge(Judge j)
        {
            // Clear old data
            if (scores.ContainsKey(j))
                scores.Remove(j);

            Dictionary<ScoringEntry, float> score = new Dictionary<ScoringEntry, float>();
            foreach (ScoringEntry entry in competitionType.getScoringEntries())
            {
                score.Add(entry, 0.0f);
            }
            scores.Add(j, score);
        }

        public void addScore(Judge judge, ScoringEntry entryKey, float value)
        {
            if (!scores.ContainsKey(judge))
            {
                scores.Add(judge, new Dictionary<ScoringEntry, float>());
            }
            (scores[judge])[entryKey] = value;
        }

        public float getTotal()
        {
            if(scores.Count == 0)
            {
                return 0.0f;
            }
            float sum = 0.0f;
            foreach(KeyValuePair<Judge, Dictionary<ScoringEntry, float>> judging in scores)
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
