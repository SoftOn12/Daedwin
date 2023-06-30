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


        public class ListToStringConverter
        {

            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (targetType != typeof(string))
                    throw new InvalidOperationException("The target must be a String");

                return String.Join(", ", ((List<string>)value).ToArray());
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

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
