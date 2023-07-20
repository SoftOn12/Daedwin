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
            RewardStage,
            EndStage
        }

        public static Stage CurentStage;

        public const int VitalityBuffOnStage = 2;

    }
}
