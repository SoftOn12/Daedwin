using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;

namespace Fight_For_Daedwin
{
    static class UIClass
    {
        public static void UIAddUnitToSlotInShop(ListBox Slot, Image CardImage, Card card)
        {
            List<string> AttributeList = new List<string>
            {
                card.Name,
                "Раса: " +card.Race,
                "Тип: " +card.Type,
                "Здоровье: " +card.Health.ToString(),
                "Атака: " +card.Attack.ToString(),
                "Выносливость: " +card.Vitality.ToString(),
                "Стоимость: " +card.Cost.ToString(),
            };

            Slot.ItemsSource = AttributeList;
            CardImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Card Arts\" + card.Image));
        }

        public static void UIAddItemToSlotInShop(ListBox Slot, Image ItemImage, Item item)
        {
            List<string> AttributeList = new List<string>
            {
                item.Name,
                "Тип: " + item.Type,
                "Бонус к Здоровью: " + item.HealthBuff.ToString(),
                "Бонус к Атаке: " + item.AttackBuff.ToString(),
                "Бонус к Выносливости: " + item.VitalityBuff.ToString(),
                "Стоимость: " + item.Cost.ToString(),
            };

            Slot.ItemsSource = AttributeList;
            ItemImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Item Arts\" + item.Image));
        }

        public static void UIAddSpellToSlotInShop(TextBlock Slot, TextBlock SpellCost, Image SpellImage, Spell spell)
        {
            SpellCost.Text = spell.Cost.ToString();
            Slot.Text = spell.Description;
            //Slot.ItemsSource = AttributeList;
            SpellImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Spell Arts\" + spell.Image));
        }

        public static void UIAddMonsterToSlotInFight(ListBox Slot, Image CardImage, Monster card)
        {
            List<string> AttributeList = new List<string>
            {
                card.Name,
                "Раса: " +card.Race,
                "Здоровье: " +card.Health.ToString(),
                "Атака: " +card.Attack.ToString()
            };

            Slot.ItemsSource = AttributeList;
            CardImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Monster Arts\" + card.Image));
        }

        public static void UIAddToSlotInCrew(ListBox Slot, Image CardImage, Card Card)
        {
            List<string> AttributeList = new List<string>
            {
                Card.Name,
                "Раса: " + Card.Race,
                "Тип: " + Card.Type,
                "Здоровье: " + Card.Health.ToString(),
                "Атака: " + Card.Attack.ToString(),
                "Выносливость: " + Card.Vitality.ToString(),
            };

            Slot.ItemsSource = AttributeList;
            CardImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Card Arts\" + Card.Image));
        }

        public static void UIRefreshCrew(ListBox Slot1, Image CardImage1, 
                                         ListBox Slot2, Image CardImage2, 
                                         ListBox Slot3, Image CardImage3,
                                         ListBox Slot4, Image CardImage4,
                                         ListBox Slot5, Image CardImage5)
        {

            UIAddToSlotInCrew(Slot1, CardImage1, CrewClass.Slot1);

            UIAddToSlotInCrew(Slot2, CardImage2, CrewClass.Slot2);

            UIAddToSlotInCrew(Slot3, CardImage3, CrewClass.Slot3);

            UIAddToSlotInCrew(Slot4, CardImage4, CrewClass.Slot4);

            UIAddToSlotInCrew(Slot5, CardImage5, CrewClass.Slot5);
        }

        public static void UIAddToSlotInInventory(ListBox Slot, Image ItemImage, Item item)
        {
            List<string> AttributeList = new List<string>
            {
                item.Name,
                "Тип: " + item.Type,
                "HP+: " + item.HealthBuff.ToString(),
                "AP+: " + item.AttackBuff.ToString(),
                "VP+: " +item.VitalityBuff.ToString(),
            };

            Slot.ItemsSource = AttributeList;
            ItemImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Item Arts\" + item.Image));
        }

        public static void UIRefreshInventory(ListBox Slot1, Image ItemImage1,
                                         ListBox Slot2, Image ItemImage2,
                                         ListBox Slot3, Image ItemImage3,
                                         ListBox Slot4, Image ItemImage4,
                                         ListBox Slot5, Image ItemImage5,
                                         ListBox Slot6, Image ItemImage6)
        {

            UIAddToSlotInInventory(Slot1, ItemImage1, InventoryClass.Slot1);

            UIAddToSlotInInventory(Slot2, ItemImage2, InventoryClass.Slot2);

            UIAddToSlotInInventory(Slot3, ItemImage3, InventoryClass.Slot3);

            UIAddToSlotInInventory(Slot4, ItemImage4, InventoryClass.Slot4);

            UIAddToSlotInInventory(Slot5, ItemImage5, InventoryClass.Slot5);

            UIAddToSlotInInventory(Slot6, ItemImage6, InventoryClass.Slot6);
        }

        public static void UIAddToSlotInSpellBook(TextBlock Slot, Image SpellImage, TextBlock spellName, Spell spell)
        {
            spellName.Text = spell.Name;
            Slot.Text = spell.Description;
            //Slot.ItemsSource = AttributeList;
            SpellImage.Source = new BitmapImage(new Uri(AppContext.BaseDirectory + @"\Spell Arts\" + spell.Image));

        }

        public static void AddTextToLog(TextBlock GameLogBox, string InputText)
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
                fstream.Write(buffer, 0, buffer.Length);

            }
            //Чтение файла (После перезаписи в локальный файл)
            CurentGameLog = File.ReadAllLines(Path);
            string GameLogBoxString = string.Join("\r\n", CurentGameLog);
            //И его последующий вывод на экран
            
            GameLogBox.Text = GameLogBoxString;
        }
    }
}
