using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;

namespace Fight_For_Daedwin
{
    static class UIClass
    {
        public static void UIAddUnitToSlotInShop(ListBox Slot, Card card)
        {
            List<string> AttributeList = new List<string>
            {
                "Юнит: " + card.Name,
                "Раса: " +card.Race,
                "Тип: " +card.Type,
                "Здоровье: " +card.Health.ToString(),
                "Атака: " +card.Attack.ToString(),
                "Выносливость: " +card.Vitality.ToString(),
                "Стоимость: " +card.Cost.ToString(),
            };

            Slot.ItemsSource = AttributeList;
        }

        public static void UIAddItemToSlotInShop(ListBox Slot, Item item)
        {
            List<string> AttributeList = new List<string>
            {
                "Предмет: " + item.Name,
                "Тип: " + item.Type,
                "Бонус к Здоровью: " + item.HealthBuff.ToString(),
                "Бонус к Атаке: " + item.AttackBuff.ToString(),
                "Бонус к Выносливости: " + item.VitalityBuff.ToString(),
                "Стоимость: " + item.Cost.ToString(),
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

        public static void UIAddToSlotInInventory(ListBox Slot, Item item)
        {
            List<string> AttributeList = new List<string>
            {
                item.Name,
                item.Type,
                item.HealthBuff.ToString(),
                item.AttackBuff.ToString(),
                item.VitalityBuff.ToString(),
            };

            Slot.ItemsSource = AttributeList;
        }

        public static void UIRefreshInventory(ListBox Slot1, ListBox Slot2, ListBox Slot3,
                                         ListBox Slot4, ListBox Slot5, ListBox Slot6)
        {

            UIAddToSlotInInventory(Slot1, InventoryClass.Slot1);

            UIAddToSlotInInventory(Slot2, InventoryClass.Slot2);

            UIAddToSlotInInventory(Slot3, InventoryClass.Slot3);

            UIAddToSlotInInventory(Slot4, InventoryClass.Slot4);

            UIAddToSlotInInventory(Slot5, InventoryClass.Slot5);

            UIAddToSlotInInventory(Slot6, InventoryClass.Slot6);
        }

        public static async void AddTextToLog(TextBlock GameLogBox, string InputText)
        {
            DateTime now = DateTime.Now;

            string FileName = "GameLog.txt";
            string Path = AppContext.BaseDirectory + @"\" + FileName;
            string Text = now.ToString("dd.MM - hh:mm:ss") + ": " + InputText + "\r\n"; // строка для записи

            if (!File.Exists(Path))
            {
                // Create a file to write to.
                string[] createText = { now.ToString("dd.MM.yyyy - hh:mm:ss") + ": " + "Добро пожаловать в игру!" };
                File.WriteAllLines(Path, createText);
            }

            //Чтение файла
            string[] CurentGameLog = File.ReadAllLines(Path);
            List<string> CurentGameLogList = new List<string>(CurentGameLog);

            if (CurentGameLogList.Count() > 50)
            {
                //Удаляем первую строку и возвращаем в файл
                CurentGameLogList.RemoveAt(0);
                File.WriteAllLines(Path, CurentGameLogList.ToArray());
            }

            // Запись в файл
            using (FileStream fstream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.UTF8.GetBytes(Text);
                // запись массива байтов в файл
                fstream.Seek(0, SeekOrigin.End);
                await fstream.WriteAsync(buffer, 0, buffer.Length);

            }
            //Чтение файла (После перезаписи в локальный файл)
            CurentGameLog = File.ReadAllLines(Path);
            string GameLogBoxString = string.Join("\r\n", CurentGameLog);
            //И его последующий вывод на экран
            
            GameLogBox.Text = GameLogBoxString;
        }
    }
}
