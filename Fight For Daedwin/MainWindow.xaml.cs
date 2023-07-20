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
            shopWindow.ShowDialog();

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
            NextFightButton.IsEnabled = false;
            GoToFightSlot1.IsEnabled = true;
            GoToFightSlot2.IsEnabled = true;
            GoToFightSlot3.IsEnabled = true;
            GoToFightSlot4.IsEnabled = true;
            GoToFightSlot5.IsEnabled = true;
            GoToFightAllSlot.IsEnabled = true;

            if (MonsterFightClass.Stage == 1)
            {
                if (CrewClass.Slot1.Name != "Не выбрано")
                    GoToFightSlot1.Visibility = Visibility.Visible;
                if (CrewClass.Slot2.Name != "Не выбрано")
                    GoToFightSlot2.Visibility = Visibility.Visible;
                if (CrewClass.Slot3.Name != "Не выбрано")
                    GoToFightSlot3.Visibility = Visibility.Visible;
                if (CrewClass.Slot4.Name != "Не выбрано")
                    GoToFightSlot4.Visibility = Visibility.Visible;
                if (CrewClass.Slot5.Name != "Не выбрано")
                    GoToFightSlot5.Visibility = Visibility.Visible;
                GoToFightAllSlot.Visibility = Visibility.Visible;

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
            GoToFightAllSlot.IsEnabled = false;
        }

        private void GoToFightSlot2_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot2);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot2.Name} из 2 слота готов к бою");
            GoToFightSlot2.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void GoToFightSlot3_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot3);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot3.Name} из 3 слота готов к бою");
            GoToFightSlot3.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void GoToFightSlot4_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot4);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot4.Name} из 4 слота готов к бою");
            GoToFightSlot4.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void GoToFightSlot5_Click(object sender, RoutedEventArgs e)
        {
            CrewClass.CardInActionList.Add(CrewClass.Slot5);
            UIClass.AddTextToLog(GameLog, $"Отряд {CrewClass.Slot5.Name} из 5 слота готов к бою");
            GoToFightSlot5.IsEnabled = false;
            GoToFightAllSlot.IsEnabled = false;
        }

        private void GoToFightAllSlot_Click(object sender, RoutedEventArgs e)
        {
            foreach (Card card in CrewClass.CrewList)
            {
                if(card.Name != "Убит" && card.Name != "Не выбрано" && card.Vitality > 0)
                    CrewClass.CardInActionList.Add(card);

            }
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

                UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);

                UIClass.UIRefreshMonsterCrew(Monster1, MonsterImage1, Monster2, MonsterImage2,
                                             Monster3, MonsterImage3);

                if (CrewClass.Slot1.Name == "Убит" || CrewClass.Slot1.Name == "Не выбрано")
                    GoToFightSlot1.Visibility = Visibility.Hidden;
                if (CrewClass.Slot2.Name == "Убит" || CrewClass.Slot2.Name == "Не выбрано")
                    GoToFightSlot2.Visibility = Visibility.Hidden;
                if (CrewClass.Slot3.Name == "Убит" || CrewClass.Slot3.Name == "Не выбрано")
                    GoToFightSlot3.Visibility = Visibility.Hidden;
                if (CrewClass.Slot4.Name == "Убит" || CrewClass.Slot4.Name == "Не выбрано")
                    GoToFightSlot4.Visibility = Visibility.Hidden;
                if (CrewClass.Slot5.Name == "Убит" || CrewClass.Slot5.Name == "Не выбрано")
                    GoToFightSlot5.Visibility = Visibility.Hidden;

                if(CrewClass.Slot1.Vitality <= 0)
                    GoToFightSlot1.Visibility = Visibility.Hidden;
                else
                    GoToFightSlot1.Visibility = Visibility.Visible;
                if (CrewClass.Slot2.Vitality <= 0)
                    GoToFightSlot2.Visibility = Visibility.Hidden;
                else
                    GoToFightSlot2.Visibility = Visibility.Visible;
                if (CrewClass.Slot3.Vitality <= 0)
                    GoToFightSlot3.Visibility = Visibility.Hidden;
                else
                    GoToFightSlot3.Visibility = Visibility.Visible;
                if (CrewClass.Slot4.Vitality <= 0)
                    GoToFightSlot4.Visibility = Visibility.Hidden;
                else
                    GoToFightSlot4.Visibility = Visibility.Visible;
                if (CrewClass.Slot5.Vitality <= 0)
                    GoToFightSlot5.Visibility = Visibility.Hidden;
                else
                    GoToFightSlot5.Visibility = Visibility.Visible;

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

        private void UseItem1_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot1;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem1.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }

        private void UseItem2_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot2;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem2.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }

        private void UseItem3_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot3;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem3.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }

        private void UseItem4_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot4;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem4.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }

        private void UseItem5_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot5;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem5.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }

        private void UseItem6_Click(object sender, RoutedEventArgs e)
        {
            InventoryClass.ChosenItem = InventoryClass.Slot6;
            if (InventoryClass.ChosenItem.Type == "Одна цель")
            {
                UseItemWindow useItemWindow = new UseItemWindow();
                useItemWindow.ShowDialog();
            }
            UIClass.UIRefreshCrew(PlayerCrew1, ImageCrew1, PlayerCrew2, ImageCrew2, PlayerCrew3, ImageCrew3,
                      PlayerCrew4, ImageCrew4, PlayerCrew5, ImageCrew5);
            UseItem6.IsEnabled = false;
            InventoryClass.ChosenItem = null;
        }
    }
}
