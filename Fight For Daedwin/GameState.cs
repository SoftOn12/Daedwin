using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    static class GameState
    {
        public enum Stage
        {
            GameStart,
            UnitShopStage,
            ItemShopStage,
            SpellChoiseStage,
            FightStage,
            EndStage
        }

        public static int MonsterProgressionIncValue = 1;
        public const int MonsterProgressionScaleHPValue = 5;
        public const int MonsterProgressionScaleAttackValue = 2;

        public static Stage CurentStage;

        public const int VitalityBuffOnStage = 2;

        static public int Money = 50;

        public const int MoneyReward = 5;

        public static string PlayerName = "Player";

        public static string ResourcePath = AppContext.BaseDirectory + @"Resources\";

    }
}
