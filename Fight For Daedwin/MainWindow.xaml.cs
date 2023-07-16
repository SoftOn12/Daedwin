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
            if(MonsterFightClass.Stage == 1)
            {
                string FileName = "MonsterDeck.xml";
                string Path = AppContext.BaseDirectory + @"\" + FileName;

                MonsterFightClass.MonsterList = MonsterFightClass.XMLParser(Path);
                MonsterFightClass.RandomMonsterToFight();

                UIClass.UIAddMonsterToSlotInFight(Monster1, MonsterImage1, EnemyCrewClass.Slot1);
                UIClass.UIAddMonsterToSlotInFight(Monster2, MonsterImage2, EnemyCrewClass.Slot2);
                UIClass.UIAddMonsterToSlotInFight(Monster3, MonsterImage3, EnemyCrewClass.Slot3);
            }
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

        private void FightButton_Click(object sender, RoutedEventArgs e)
        {
            MonsterFightClass.FightAction();
        }
    }
}
