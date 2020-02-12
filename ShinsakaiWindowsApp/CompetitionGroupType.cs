using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public enum CompetitionGroupType
    {
        Katatedori,
        Katatedori_Ryotemochi,
        Yokomenuchi,
        Rolling,
        Kitei,
        JoNage,
        GroupType1,
        GroupType2,
        GroupType3
    }

    public static class CompetitionEntryProvider
    {
        public static List<ScoringEntry> getScoringEntries(this CompetitionGroupType t)
        {
            switch (t)
            {
                case CompetitionGroupType.Kitei:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Shomenuchi_Kokyunage_1,
                        ScoringEntry.Shomenuchi_Kokyunage_2,
                        ScoringEntry.Shomenuchi_Kokyunage_3,
                        ScoringEntry.Yokomenuchi_Shihonage_1,
                        ScoringEntry.Yokomenuchi_Shihonage_2,
                        ScoringEntry.Yokomenuchi_Shihonage_3,
                        ScoringEntry.Munetsuki_Kotegaeshi_1,
                        ScoringEntry.Munetsuki_Kotegaeshi_2,
                        ScoringEntry.Munetsuki_Kotegaeshi_3,
                        ScoringEntry.Katatetori_Tenkan_Ikkyo_1,
                        ScoringEntry.Katatetori_Tenkan_Ikkyo_2,
                        ScoringEntry.Katatetori_Tenkan_Ikkyo_3,
                        ScoringEntry.Katadori_Nikyo_1,
                        ScoringEntry.Katadori_Nikyo_2,
                        ScoringEntry.Katadori_Nikyo_3,
                        ScoringEntry.Ushiro_Tekubidori_Sankyo_1,
                        ScoringEntry.Ushiro_Tekubidori_Sankyo_2,
                        ScoringEntry.Ushiro_Tekubidori_Sankyo_3
                    };
                default:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Entry1,
                        ScoringEntry.Entry2,
                        ScoringEntry.Entry3,
                        ScoringEntry.Entry4
                    };
            }
        }
    }
}
