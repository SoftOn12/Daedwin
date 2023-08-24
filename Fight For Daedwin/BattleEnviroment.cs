using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    class BattleEnviroment
    {

        static public Enviroment CurrentEnviroment = new Enviroment();

        static public int BattleEnviromentSize = 0;

        static public void RefreshBattleEnviroment()
        {
            CurrentEnviroment = new Enviroment();
            BattleEnviromentSize = 0;
        }

    }
}
