using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    static class EnemyCrewClass
    {
        static public Monster Slot1 = new Monster();
        static public Monster Slot2 = new Monster();
        static public Monster Slot3 = new Monster();

        static public List<Monster> CrewList = new List<Monster>() { Slot1, Slot2, Slot3 };

        static public int EnemyCrewSize = 0;
    }
}
