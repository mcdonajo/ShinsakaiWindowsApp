using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public enum ScoringEntry
    {
        //Kitei
        Shomenuchi_Kokyunage,
        Yokomenuchi_Shihonage,
        Munetsuki_Kotegaeshi,
        Katatetori_Tenkan_Ikkyo,
        Katadori_Nikyo,
        Ushiro_Tekubidori_Sankyo,

        //JoNage
        Kokyunage,
        Kokyunage_Zenponage,
        Sakatemochi_Kokyunage_Zenponage,
        Shihonage,
        Nikyo,
        Kotegaeshi,
        Kokyunage_Kirikaeshi,
        Kokyunage_Ashisuki,

        //Tantadori
        Syomenuchi_Kotegaeshi,
        Syomenuchi_Kokyunage,
        Sakatemochi_Yokomenuchi_irimi_Gokyo,
        Sakatemochi_Kokyunage,
        Yokomenuchi_Kokyunage,
        Munetsuki_ikkyo_irimi,
        Munetsuki_Kokyunage_Zenponage,
        Munetsuki_Kokyunage_Hijuchi_Menuchi,
        Munetsuki_Kokyunage_Keitenage,

        //Taigi 5
        Munetsuki_Koteoroshi_Katameru,
        Katatori_Ikkyo_Irimi,
        Koyku_Dosa,

        //Taigi 12
        Kokyunage_Irimi,
        Kokyunage_Tenkan,
        Ikkyo,
        Kokyunage_Zempo_Nage,
        Kokyunage_Ball_Nage,

        //Taigi 13
        Kokyunage_Juji_Irimi,
        Kokyunage_Atemi,
        Shihonage_Irimi_Tobikomi,
        Kotegaeshi_Enundo,
        Kokyunage_KiriKaeshi,

        Entry
    }

    public static class ScoringEntryTextProvider
    {
        public static string getDesc(this ScoringEntry t)
        {
            switch (t)
            {
                // Kitei
                case ScoringEntry.Shomenuchi_Kokyunage:
                    return "Shomenuchi Kokyunage";
                case ScoringEntry.Yokomenuchi_Shihonage:
                    return "Yokomenuchi Shihonage ";
                case ScoringEntry.Munetsuki_Kotegaeshi:
                    return "Munetsuki Kotegaeshi";
                case ScoringEntry.Katatetori_Tenkan_Ikkyo:
                    return "Katatetori Tenkan Ikkyo";
                case ScoringEntry.Katadori_Nikyo:
                    return "Katadori Nikkyo";
                case ScoringEntry.Ushiro_Tekubidori_Sankyo:
                    return "Ushiro Tekubidori Sankyo ";
                // Other
                case ScoringEntry.Entry:
                    return "Entry";
                default:
                    return t.ToString();
            }
        }
    }
}
