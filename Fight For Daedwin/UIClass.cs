using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Fight_For_Daedwin
{
    static class UIClass
    {
        public static void UIAddToSlotInShop(ListBox Slot, Card Card)
        {
            List<string> AttributeList = new List<string>
            {
                "Название карты: " + Card.Name,
                "Раса: " +Card.Race,
                "Тип: " +Card.Type,
                "Здоровье: " +Card.Health.ToString(),
                "Атака: " +Card.Attack.ToString(),
                "Выносливость: " +Card.Vitality.ToString(),
                "Стоимость: " +Card.Cost.ToString(),
            };

            Slot.ItemsSource = AttributeList;
        }

        public static void UIAddToSlotInCrew(ListBox Slot, Card Card)
        {
            List<string> AttributeList = new List<string>
            {
                Card.Name,
                Card.Race,
                Card.Type,
                Card.Health.ToString(),
                Card.Attack.ToString(),
                Card.Vitality.ToString(),
            };

            Slot.ItemsSource = AttributeList;
        }

        public static void UIRefreshCrew(ListBox Slot1, ListBox Slot2, ListBox Slot3,
                                         ListBox Slot4, ListBox Slot5)
        {
            UIAddToSlotInCrew(Slot1, CrewClass.Slot1);
            UIAddToSlotInCrew(Slot2, CrewClass.Slot2);
            UIAddToSlotInCrew(Slot3, CrewClass.Slot3);
            UIAddToSlotInCrew(Slot4, CrewClass.Slot4);
            UIAddToSlotInCrew(Slot5, CrewClass.Slot5);
        }
    }
}
