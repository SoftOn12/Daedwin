using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight_For_Daedwin
{
    static class RewardClass
    {
        static public Item FirstItemSlot = new Item();
        static public Item SecondItemSlot = new Item();
        static public Item ThirdItemSlot = new Item();

        static public List<Item> RewardItemList;

        public static void RandomItemToReward()
        {
            RewardItemList = ShopClass.ItemList;

            if (RewardItemList.Count != 0)
            {
                Random Rnd = new Random();
                int Seed = Rnd.Next(RewardItemList.Count);

                FirstItemSlot.Name = RewardItemList[Seed].Name;
                FirstItemSlot.Type = RewardItemList[Seed].Type;
                FirstItemSlot.HealthBuff = RewardItemList[Seed].HealthBuff;
                FirstItemSlot.AttackBuff = RewardItemList[Seed].AttackBuff;
                FirstItemSlot.VitalityBuff = RewardItemList[Seed].VitalityBuff;
                FirstItemSlot.Cost = RewardItemList[Seed].Cost;
                FirstItemSlot.Image = RewardItemList[Seed].Image;

                Seed = Rnd.Next(RewardItemList.Count);

                SecondItemSlot.Name = RewardItemList[Seed].Name;
                SecondItemSlot.Type = RewardItemList[Seed].Type;
                SecondItemSlot.HealthBuff = RewardItemList[Seed].HealthBuff;
                SecondItemSlot.AttackBuff = RewardItemList[Seed].AttackBuff;
                SecondItemSlot.VitalityBuff = RewardItemList[Seed].VitalityBuff;
                SecondItemSlot.Cost = RewardItemList[Seed].Cost;
                SecondItemSlot.Image = RewardItemList[Seed].Image;

                Seed = Rnd.Next(RewardItemList.Count);

                ThirdItemSlot.Name = RewardItemList[Seed].Name;
                ThirdItemSlot.Type = RewardItemList[Seed].Type;
                ThirdItemSlot.HealthBuff = RewardItemList[Seed].HealthBuff;
                ThirdItemSlot.AttackBuff = RewardItemList[Seed].AttackBuff;
                ThirdItemSlot.VitalityBuff = RewardItemList[Seed].VitalityBuff;
                ThirdItemSlot.Cost = RewardItemList[Seed].Cost;
                ThirdItemSlot.Image = RewardItemList[Seed].Image;
            }
            else
            {
                Console.WriteLine("Список карт пуст!");
                return;
            }
        }

        static public void FromRewardToInventory(Item CardFromShop)
        {
            switch (InventoryClass.InventorySize)
            {
                case 0:
                    InventoryClass.Slot1.Name = CardFromShop.Name;
                    InventoryClass.Slot1.Type = CardFromShop.Type;
                    InventoryClass.Slot1.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot1.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot1.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot1.Cost = CardFromShop.Cost;
                    InventoryClass.Slot1.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 1:
                    InventoryClass.Slot2.Name = CardFromShop.Name;
                    InventoryClass.Slot2.Type = CardFromShop.Type;
                    InventoryClass.Slot2.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot2.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot2.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot2.Cost = CardFromShop.Cost;
                    InventoryClass.Slot2.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 2:
                    InventoryClass.Slot3.Name = CardFromShop.Name;
                    InventoryClass.Slot3.Type = CardFromShop.Type;
                    InventoryClass.Slot3.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot3.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot3.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot3.Cost = CardFromShop.Cost;
                    InventoryClass.Slot3.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 3:
                    InventoryClass.Slot4.Name = CardFromShop.Name;
                    InventoryClass.Slot4.Type = CardFromShop.Type;
                    InventoryClass.Slot4.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot4.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot4.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot4.Cost = CardFromShop.Cost;
                    InventoryClass.Slot4.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 4:
                    InventoryClass.Slot5.Name = CardFromShop.Name;
                    InventoryClass.Slot5.Type = CardFromShop.Type;
                    InventoryClass.Slot5.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot5.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot5.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot5.Cost = CardFromShop.Cost;
                    InventoryClass.Slot5.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                case 5:
                    InventoryClass.Slot6.Name = CardFromShop.Name;
                    InventoryClass.Slot6.Type = CardFromShop.Type;
                    InventoryClass.Slot6.HealthBuff = CardFromShop.HealthBuff;
                    InventoryClass.Slot6.AttackBuff = CardFromShop.AttackBuff;
                    InventoryClass.Slot6.VitalityBuff = CardFromShop.VitalityBuff;
                    InventoryClass.Slot6.Cost = CardFromShop.Cost;
                    InventoryClass.Slot6.Image = CardFromShop.Image;
                    InventoryClass.InventorySize++;
                    break;
                default:
                    break;
            }
        }
    }
}
