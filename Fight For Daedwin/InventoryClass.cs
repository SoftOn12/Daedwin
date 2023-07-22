using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    static class InventoryClass
    {
        static public Item Slot1 = new Item();
        static public Item Slot2 = new Item();
        static public Item Slot3 = new Item();
        static public Item Slot4 = new Item();
        static public Item Slot5 = new Item();
        static public Item Slot6 = new Item();

        static public int InventorySize = 0;

        static public Item ChosenItem;

        static public void RefreshInventory()
        {
            Slot1 = new Item();
            Slot2 = new Item();
            Slot3 = new Item();
            Slot4 = new Item();
            Slot5 = new Item();
            Slot6 = new Item();
            InventorySize = 0;
        }

        static public void SortSlots()
        {
            for(int i = 0; i< 6; i++)
            {
                if(Slot1.Image == "Default.png")
                {
                    Slot1 = Slot2;
                    Slot2 = Slot3;
                    Slot3 = Slot4;
                    Slot4 = Slot5;
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
                if (Slot2.Image == "Default.png")
                {
                    Slot2 = Slot3;
                    Slot3 = Slot4;
                    Slot4 = Slot5;
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
                if (Slot3.Image == "Default.png")
                {
                    Slot3 = Slot4;
                    Slot4 = Slot5;
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
                if (Slot3.Image == "Default.png")
                {
                    Slot3 = Slot4;
                    Slot4 = Slot5;
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
                if (Slot4.Image == "Default.png")
                {
                    Slot4 = Slot5;
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
                if (Slot5.Image == "Default.png")
                {
                    Slot5 = Slot6;
                    Slot6 = new Item();
                }
            }
        }
    }
}
