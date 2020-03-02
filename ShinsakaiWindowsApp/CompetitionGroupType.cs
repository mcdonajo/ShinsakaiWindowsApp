using System.Collections.Generic;

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
        Tantodori,
        Taigi_5,
        Taigi_12,
        Taigi_13,
        //Default
        Unknown,
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
                        ScoringEntry.Shomenuchi_Kokyunage,
                        ScoringEntry.Yokomenuchi_Shihonage,
                        ScoringEntry.Munetsuki_Kotegaeshi,
                        ScoringEntry.Katatetori_Tenkan_Ikkyo,
                        ScoringEntry.Katadori_Nikyo,
                        ScoringEntry.Ushiro_Tekubidori_Sankyo
                    };
                case CompetitionGroupType.JoNage:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Kokyunage,
                        ScoringEntry.Kokyunage_Zenponage,
                        ScoringEntry.Sakatemochi_Kokyunage_Zenponage,
                        ScoringEntry.Shihonage,
                        ScoringEntry.Nikyo,
                        ScoringEntry.Kotegaeshi,
                        ScoringEntry.Kokyunage_Kirikaeshi,
                        ScoringEntry.Kokyunage_Ashisuki
                    };
                case CompetitionGroupType.Tantodori:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Syomenuchi_Kotegaeshi,
                        ScoringEntry.Syomenuchi_Kokyunage,
                        ScoringEntry.Sakatemochi_Yokomenuchi_irimi_Gokyo,
                        ScoringEntry.Sakatemochi_Kokyunage,
                        ScoringEntry.Yokomenuchi_Kokyunage,
                        ScoringEntry.Munetsuki_Kotegaeshi,
                        ScoringEntry.Munetsuki_ikkyo_irimi,
                        ScoringEntry.Munetsuki_Kokyunage_Zenponage,
                        ScoringEntry.Munetsuki_Kokyunage_Hijuchi_Menuchi,
                        ScoringEntry.Munetsuki_Kokyunage_Keitenage,
                    };
                case CompetitionGroupType.Taigi_5:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Shomenuchi_Kokyunage,
                        ScoringEntry.Yokomenuchi_Shihonage,
                        ScoringEntry.Munetsuki_Koteoroshi_Katameru,
                        ScoringEntry.Katatori_Ikkyo_Irimi,
                        ScoringEntry.Koyku_Dosa
                    };
                case CompetitionGroupType.Taigi_12:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Kokyunage_Irimi,
                        ScoringEntry.Kokyunage_Tenkan,
                        ScoringEntry.Nikyo,
                        ScoringEntry.Ikkyo,
                        ScoringEntry.Kokyunage_Zempo_Nage,
                        ScoringEntry.Kokyunage_Ball_Nage
                    };
                case CompetitionGroupType.Taigi_13:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Kokyunage_Irimi,
                        ScoringEntry.Kokyunage_Juji_Irimi,
                        ScoringEntry.Kokyunage_Atemi,
                        ScoringEntry.Shihonage_Irimi_Tobikomi,
                        ScoringEntry.Kotegaeshi_Enundo,
                        ScoringEntry.Kokyunage_KiriKaeshi
                    };
                default:
                    return new List<ScoringEntry>
                    {
                        ScoringEntry.Entry
                    };
            }
        }
    }
}
