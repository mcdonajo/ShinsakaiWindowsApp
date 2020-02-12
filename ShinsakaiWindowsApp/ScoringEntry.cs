using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public enum ScoringEntry
    {
        Shomenuchi_Kokyunage_1,
        Shomenuchi_Kokyunage_2,
        Shomenuchi_Kokyunage_3,
        Yokomenuchi_Shihonage_1,
        Yokomenuchi_Shihonage_2,
        Yokomenuchi_Shihonage_3,
        Munetsuki_Kotegaeshi_1,
        Munetsuki_Kotegaeshi_2,
        Munetsuki_Kotegaeshi_3,
        Katatetori_Tenkan_Ikkyo_1,
        Katatetori_Tenkan_Ikkyo_2,
        Katatetori_Tenkan_Ikkyo_3,
        Katadori_Nikyo_1,
        Katadori_Nikyo_2,
        Katadori_Nikyo_3,
        Ushiro_Tekubidori_Sankyo_1,
        Ushiro_Tekubidori_Sankyo_2,
        Ushiro_Tekubidori_Sankyo_3,
        Entry1,
        Entry2,
        Entry3,
        Entry4
    }

    public static class ScoringEntryTextProvider
    {
        public static String getDesc(this ScoringEntry t)
        {
            switch (t)
            {
                // Kitei
                case ScoringEntry.Shomenuchi_Kokyunage_1:
                    return "(1) When ki moves, enter straight behind uke";
                case ScoringEntry.Shomenuchi_Kokyunage_2:
                    return "(2) Raise both arms";
                case ScoringEntry.Shomenuchi_Kokyunage_3:
                    return "(3) Bring arms straight down, lead straight up and down";
                case ScoringEntry.Yokomenuchi_Shihonage_1:
                    return "Yokomenuchi Shihonage 1";
                case ScoringEntry.Yokomenuchi_Shihonage_2:
                    return "Yokomenuchi Shihonage 2";
                case ScoringEntry.Yokomenuchi_Shihonage_3:
                    return "Yokomenuchi Shihonage 3";
                case ScoringEntry.Munetsuki_Kotegaeshi_1:
                    return "Munetsuki Kotegaeshi 1";
                case ScoringEntry.Munetsuki_Kotegaeshi_2:
                    return "Munetsuki Kotegaeshi 2";
                case ScoringEntry.Munetsuki_Kotegaeshi_3:
                    return "Munetsuki Kotegaeshi 3";
                case ScoringEntry.Katatetori_Tenkan_Ikkyo_1:
                    return "Katatetori Tenkan Ikkyo 1";
                case ScoringEntry.Katatetori_Tenkan_Ikkyo_2:
                    return "Katatetori Tenkan Ikkyo 2";
                case ScoringEntry.Katatetori_Tenkan_Ikkyo_3:
                    return "Katatetori Tenkan Ikkyo 3";
                case ScoringEntry.Katadori_Nikyo_1:
                    return "Katadori Nikkyo 1";
                case ScoringEntry.Katadori_Nikyo_2:
                    return "Katadori Nikkyo 2";
                case ScoringEntry.Katadori_Nikyo_3:
                    return "Katadori Nikkyo 3";
                case ScoringEntry.Ushiro_Tekubidori_Sankyo_1:
                    return "Ushiro Tekubidori Sankyo 1";
                case ScoringEntry.Ushiro_Tekubidori_Sankyo_2:
                    return "Ushiro Tekubidori Sankyo 2";
                case ScoringEntry.Ushiro_Tekubidori_Sankyo_3:
                    return "Ushiro Tekubidori Sankyo 3";
                // Other
                case ScoringEntry.Entry1:
                    return "Entry1";
                case ScoringEntry.Entry2:
                    return "Entry2";
                case ScoringEntry.Entry3:
                    return "Entry3";
                case ScoringEntry.Entry4:
                    return "Entry4";
            }
            return "Missing";
        }
    }
}
