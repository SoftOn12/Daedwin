using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Fight_For_Daedwin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shopWindow = new ShopWindow();
            shopWindow.Show();

            StartButton.IsEnabled = false;
            GameLogParent.Visibility = Visibility.Visible;

            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                            PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);

            UIClass.UIRefreshInventory(Item1, ImageItem1, Item2, ImageItem2, Item3, ImageItem3,
                                            Item4, ImageItem4,Item5, ImageItem5,Item6, ImageItem6);

            UIClass.UIAddToSlotInSpellBook(SpellText, SpellImage,SpellTitle, SpellBookClass.PlayerSpell);
        }

        private void NextFightButton_Click(object sender, RoutedEventArgs e)
        {
            int curentStage = MonsterFightClass.Stage;

            NextFightButton.IsEnabled = false;

            GoToFightSlot1.Visibility = Visibility.Visible;
            GoToFightSlot2.Visibility = Visibility.Visible;
            GoToFightSlot3.Visibility = Visibility.Visible;
            GoToFightSlot4.Visibility = Visibility.Visible;
            GoToFightSlot5.Visibility = Visibility.Visible;
            GoToFightAllSlot.Visibility = Visibility.Visible;
            GoToFightSlot1.IsEnabled = true;
            GoToFightSlot2.IsEnabled = true;
            GoToFightSlot3.IsEnabled = true;
            GoToFightSlot4.IsEnabled = true;
            GoToFightSlot5.IsEnabled = true;
            GoToFightAllSlot.IsEnabled = true;

            if (MonsterFightClass.Stage == 1)
            {
                string FileName = "MonsterDeck.xml";
                string Path = AppContext.BaseDirectory + @"\" + FileName;
                MonsterFightClass.MonsterList = MonsterFightClass.XMLParser(Path);

                List<string> BattleInfoList = new List<string>
            {
                $"Уровень: {MonsterFightClass.Stage}",
            };
                BattleInfo.ItemsSource = BattleInfoList;
            }

                MonsterFightClass.RandomMonsterToFight();
                UIClass.UIRefreshMonsterCrew(Monster1, MonsterImage1,
                    Monster2, MonsterImage2, Monster3, MonsterImage3);
        }

        private void GoToFightSlot1_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot1);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot1.Name} из 1 слота готов к бою");
            GoToFightSlot1.IsEnabled = false;
        }

        private void GoToFightSlot2_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot2);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot2.Name} из 2 слота готов к бою");
            GoToFightSlot2.IsEnabled = false;
        }

        private void GoToFightSlot3_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot3);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot3.Name} из 3 слота готов к бою");
            GoToFightSlot3.IsEnabled = false;
        }

        private void GoToFightSlot4_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot4);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot4.Name} из 4 слота готов к бою");
            GoToFightSlot4.IsEnabled = false;
        }

        private void GoToFightSlot5_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot5);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot5.Name} из 5 слота готов к бою");
            GoToFightSlot5.IsEnabled = false;
        }

        private void GoToFightAllSlot_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot1);
            CrewClass.CardInActionList.Add(CrewClass.Slot2);
            CrewClass.CardInActionList.Add(CrewClass.Slot3);
            CrewClass.CardInActionList.Add(CrewClass.Slot4);
            CrewClass.CardInActionList.Add(CrewClass.Slot5);
            UIClass.AddTextToLog(GameLog, $"Все отряды готовы к бою");
            GoToFightSlot1.IsEnabled = false;
            GoToFightSlot2.IsEnabled = false;
            GoToFightSlot3.IsEnabled = false;
            GoToFightSlot4.IsEnabled = false;
            GoToFightSlot5.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            if (CrewClass.CardInActionList.Count == 0)
            {
                UIClass.AddTextToLog(GameLog, $"Выберете бойцов для боя!");
            }
            else
            {
                int crew1Health = CrewClass.Slot1.Health;
                int crew2Health = CrewClass.Slot2.Health;
                int crew3Health = CrewClass.Slot3.Health;
                int crew4Health = CrewClass.Slot4.Health;
                int crew5Health = CrewClass.Slot5.Health;

                MonsterFightClass.FightAction();

                List<string> BattleInfoList = new List<string>
            {
                $"Уровень: {MonsterFightClass.Stage}",
                $"Первый отряд потерял {crew1Health - CrewClass.Slot1.Health} HP",
                $"Второй отряд потерял {crew2Health - CrewClass.Slot2.Health} HP",
                $"Третий отряд потерял {crew3Health - CrewClass.Slot3.Health} HP",
                $"Четвертый отряд потерял {crew4Health - CrewClass.Slot4.Health} HP",
                $"Пятый отряд потерял {crew5Health - CrewClass.Slot5.Health} HP",
            };
                BattleInfo.ItemsSource = BattleInfoList;
                NextFightButton.IsEnabled = true;
                CrewClass.CardInActionList.Clear();
            }
        }
    }
}
