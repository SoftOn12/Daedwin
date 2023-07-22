using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    static class CrewClass
    {
        static public Card Slot1 = new Card();
        static public Card Slot2 = new Card();
        static public Card Slot3 = new Card();
        static public Card Slot4 = new Card();
        static public Card Slot5 = new Card();

        static public List<Card> CrewList = new List<Card>() { Slot1, Slot2, Slot3, Slot4, Slot5 } ;

        static public List<Card> CardInActionList = new List<Card>(); //Список карт, учавствующие в файте

        static public int CrewSize = 0;

        static public void RefreshCrew()
        {
            Slot1 = new Card();
            Slot2 = new Card();
            Slot3 = new Card();
            Slot4 = new Card();
            Slot5 = new Card();
            CrewSize = 0;
        }
    }
}
